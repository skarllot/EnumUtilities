# PowerShell script to clean up CS files generated from TT files
# Removes #line directives and collapses multiple blank lines

function Find-RepositoryRoot {
    param([string]$StartPath)

    $currentPath = $StartPath

    while ($currentPath -ne $null -and $currentPath -ne "") {
        $gitPath = Join-Path $currentPath ".git"
        if (Test-Path $gitPath) {
            return $currentPath
        }

        $parentPath = Split-Path $currentPath -Parent
        if ($parentPath -eq $currentPath) {
            # Reached the root of the drive
            break
        }
        $currentPath = $parentPath
    }

    throw "Repository root with .git folder not found"
}

function Remove-LineDirectives {
    param([string[]]$Lines)

    return $Lines | Where-Object {
        $trimmedLine = $_.TrimStart()
        -not $trimmedLine.StartsWith("#line")
    }
}

function Collapse-BlankLines {
    param([string[]]$Lines)

    $result = @()
    $previousLineWasBlank = $false

    foreach ($line in $Lines) {
        $isBlankLine = [string]::IsNullOrWhiteSpace($line)

        if ($isBlankLine) {
            if (-not $previousLineWasBlank) {
                $result += ""  # Add a single blank line
                $previousLineWasBlank = $true
            }
            # Skip additional blank lines
        } else {
            $result += $line
            $previousLineWasBlank = $false
        }
    }

    return $result
}

function Remove-ToStringHelperCalls {
    param([string[]]$Lines)

    return $Lines | ForEach-Object {
        $_ -replace 'this\.ToStringHelper\.ToStringWithCulture', ''
    }
}

function Normalize-LineEndings {
    param([string[]]$Lines)

    return $Lines | ForEach-Object {
        $_ -replace '\\r\\n', '\n'
    }
}

function Remove-BlankLinesBetweenWrites {
    param([string[]]$Lines)

    $result = @()
    $i = 0

    while ($i -lt $Lines.Length) {
        $currentLine = $Lines[$i]

        # Check if current line contains this.Write, next line is blank, and line after is this.Write
        if ($currentLine -match 'this\.Write' -and
            $i + 2 -lt $Lines.Length -and
            [string]::IsNullOrWhiteSpace($Lines[$i + 1]) -and
            $Lines[$i + 2] -match 'this\.Write') {
            # Add current line and skip the blank line
            $result += $currentLine
            $i += 2
        } else {
            $result += $currentLine
            $i++
        }
    }

    return $result
}

function Process-CsFile {
    param([string]$CsFilePath)

    if (-not (Test-Path $CsFilePath)) {
        Write-Warning "CS file not found: $CsFilePath"
        return
    }

    Write-Host "Processing: $CsFilePath"

    try {
        # Read all lines from the CS file
        $lines = Get-Content $CsFilePath -Encoding UTF8

        # Remove #line directives
        $linesWithoutDirectives = Remove-LineDirectives -Lines $lines

        # Remove ToStringHelper calls
        $linesWithoutToStringHelper = Remove-ToStringHelperCalls -Lines $linesWithoutDirectives

        # Collapse multiple blank lines
        $linesCollapsed = Collapse-BlankLines -Lines $linesWithoutToStringHelper

        # Remove blank lines between consecutive this.Write calls
        $linesWithoutWriteGaps = Remove-BlankLinesBetweenWrites -Lines $linesCollapsed

        # Normalize line endings (\r\n to \n)
        $finalLines = Normalize-LineEndings -Lines $linesWithoutWriteGaps

        # Extract auto-generated header (from start to second "// --------------")
        $header = @()
        $contentStartIndex = 0
        $dashLineCount = 0

        for ($i = 0; $i -lt $finalLines.Length; $i++) {
            if ($finalLines[$i] -match '^// --------------') {
                $dashLineCount++
                if ($dashLineCount -eq 2) {
                    $header = $finalLines[0..$i]
                    $contentStartIndex = $i + 1
                    break
                }
            }
        }

        # Write content without header to file
        if ($contentStartIndex -gt 0) {
            $finalLines[$contentStartIndex..($finalLines.Length - 1)] | Set-Content $CsFilePath -Encoding UTF8
        } else {
            $finalLines | Set-Content $CsFilePath -Encoding UTF8
        }

        # Format the file with CSharpier
        Write-Host "Formatting with CSharpier: $CsFilePath"
        $formatResult = & dotnet tool run csharpier format $CsFilePath --include-generated 2>&1
        if ($LASTEXITCODE -ne 0) {
            Write-Warning "CSharpier formatting failed for $CsFilePath`: $formatResult"
        }

        # Restore header if it was extracted
        if ($contentStartIndex -gt 0) {
            $formattedContent = Get-Content $CsFilePath -Encoding UTF8
            $finalContent = $header + $formattedContent
            $finalContent | Set-Content $CsFilePath -Encoding UTF8
        }

        Write-Host "Successfully processed: $CsFilePath"
    }
    catch {
        Write-Error "Error processing $CsFilePath`: $($_.Exception.Message)"
    }
}

# Main execution
try {
    # Get the directory where this script is located
    $scriptPath = if ($PSScriptRoot) { $PSScriptRoot } else { Split-Path $MyInvocation.MyCommand.Path }

    Write-Host "Script location: $scriptPath"

    # Find repository root
    $repoRoot = Find-RepositoryRoot -StartPath $scriptPath
    Write-Host "Repository root found: $repoRoot"

    # Find all TT files in the repository
    $ttFiles = Get-ChildItem -Path $repoRoot -Filter "*.tt" -Recurse
    Write-Host "Found $($ttFiles.Count) TT files"

    if ($ttFiles.Count -eq 0) {
        Write-Host "No TT files found in the repository"
        exit 0
    }

    # Process each TT file's corresponding CS file
    $processedCount = 0
    foreach ($ttFile in $ttFiles) {
        # Get the corresponding CS file path
        $csFilePath = [System.IO.Path]::ChangeExtension($ttFile.FullName, ".cs")

        Write-Host "`nChecking for CS file: $csFilePath"

        if (Test-Path $csFilePath) {
            Process-CsFile -CsFilePath $csFilePath
            $processedCount++
        } else {
            Write-Warning "Corresponding CS file not found for: $($ttFile.FullName)"
        }
    }

    Write-Host "`n=== Summary ==="
    Write-Host "TT files found: $($ttFiles.Count)"
    Write-Host "CS files processed: $processedCount"
    Write-Host "Script completed successfully"
}
catch {
    Write-Error "Script execution failed: $($_.Exception.Message)"
    exit 1
}
