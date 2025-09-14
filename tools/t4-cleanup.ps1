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

        # Collapse multiple blank lines
        $finalLines = Collapse-BlankLines -Lines $linesWithoutDirectives

        # Write back to the file (overwrite)
        $finalLines | Set-Content $CsFilePath -Encoding UTF8

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
