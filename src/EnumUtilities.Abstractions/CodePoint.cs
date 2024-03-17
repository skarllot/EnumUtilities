namespace Raiqub.Generators.EnumUtilities;

internal readonly struct CodePoint : IEquatable<CodePoint>
{
    public readonly uint Value;

    public CodePoint(char value) => Value = value;

    public CodePoint(char highSurrogate, char lowSurrogate) =>
        Value = (uint)char.ConvertToUtf32(highSurrogate, lowSurrogate);

    public CodePoint(uint value) => Value = value;

    public CodePoint(int value) => Value = (uint)value;

    public static bool operator ==(CodePoint left, CodePoint right) => left.Value == right.Value;

    public static bool operator ==(CodePoint left, char right) => left.Value == right;

    public static bool operator !=(CodePoint left, CodePoint right) => left.Value != right.Value;

    public static bool operator !=(CodePoint left, char right) => left.Value != right;

    public static implicit operator CodePoint(uint value) => new(value);

    public static implicit operator CodePoint(int value) => new(value);

    public static implicit operator CodePoint(char value) => new(value);

    public bool IsAscii => Value <= 0x7Fu;

    /// <summary>Returns a value that indicates whether this value is categorized as an ASCII digit.</summary>
    public bool IsAsciiDigit => Value is >= '0' and <= '9';

    public bool IsBmp => Value <= 0xFFFFu;

    public bool IsWhiteSpace => IsBmp && char.IsWhiteSpace((char)Value);

    public int Utf16SequenceLength
    {
        get
        {
            uint v = Value;
            v -= 0x10000; // if value < 0x10000, high byte = 0xFF; else high byte = 0x00
            v += 2 << 24; // if value < 0x10000, high byte = 0x01; else high byte = 0x02
            v >>= 24; // shift high byte down
            return (int)v; // and return it
        }
    }

    public int Utf8SequenceLength
    {
        get
        {
            uint v = Value;
            int a = ((int)v - 0x0800) >> 31;

            v ^= 0xF800u;
            v -= 0xF880u; // if scalar is 1 or 3 code units, high byte = 0xFF; else high byte = 0x00
            v += 4 << 24; // if scalar is 1 or 3 code units, high byte = 0x03; else high byte = 0x04
            v >>= 24; // shift high byte down

            // Final return value:
            // - U+0000..U+007F => 3 + (-1) * 2 = 1
            // - U+0080..U+07FF => 4 + (-1) * 2 = 2
            // - U+0800..U+FFFF => 3 + ( 0) * 2 = 3
            // - U+10000+       => 4 + ( 0) * 2 = 4
            return (int)v + (a * 2);
        }
    }

    public static bool TryGetCodePointAt(ReadOnlySpan<char> input, int index, out CodePoint result)
    {
        result = default;
        char returnValue = input[index];

        if (char.IsSurrogate(returnValue))
        {
            if (!char.IsHighSurrogate(returnValue))
                return false;

            index++;
            if (index >= input.Length)
                return false;

            char potentialLowSurrogate = input[index];
            if (!char.IsLowSurrogate(potentialLowSurrogate))
                return false;

            result = (uint)((returnValue << 10) + potentialLowSurrogate - ((0xD800U << 10) + 0xDC00U - (1 << 16)));
            return true;
        }

        result = returnValue;
        return true;
    }

    public static bool TryGetFirstCodePoint(ReadOnlySpan<byte> source, out CodePoint result)
    {
        result = default;
        if (source.IsEmpty)
        {
            return false; // Input byte array is empty
        }

        // Decode the first byte to get the character
        int firstByte = source[0];
        if (firstByte < 0x80)
        {
            result = firstByte; // Single-byte character
            return true;
        }

        // Multi-byte character
        if ((firstByte & 0xE0) == 0xC0) // 2-byte character (110 followed by 6 bits)
        {
            if (source.Length < 2 || (source[1] & 0x80) != 0x80)
            {
                result = 0xFFFD;
                return false; // Invalid sequence, return replacement character
            }

            result = ((firstByte & 0x1F) << 6) |
                     (source[1] & 0x3F);
            return true;
        }

        if ((firstByte & 0xF0) == 0xE0) // 3-byte character (1110 followed by 6+6 bits)
        {
            if (source.Length < 3 || (source[1] & 0x80) != 0x80 || (source[2] & 0x80) != 0x80)
            {
                result = 0xFFFD; // Invalid sequence, return replacement character
                return false;
            }

            result = ((firstByte & 0xF) << 12) |
                     ((source[1] & 0x3F) << 6) |
                     (source[2] & 0x3F);
            return true;
        }

        if ((firstByte & 0xF8) == 0xF0) // 4-byte character (11110 followed by 6+6+6 bits)
        {
            if (source.Length < 4 || (source[1] & 0x80) != 0x80 || (source[2] & 0x80) != 0x80 ||
                (source[3] & 0x80) != 0x80)
            {
                result = 0xFFFD; // Invalid sequence, return replacement character
                return false;
            }

            result = ((firstByte & 0x7) << 18) |
                     ((source[1] & 0x3F) << 12) |
                     ((source[2] & 0x3F) << 6) |
                     (source[3] & 0x3F);
            return true;
        }

        // Invalid sequence or unexpected byte value, return replacement character
        result = 0xFFFD;
        return false;
    }

    public void EncodeToUtf16(out char c1, out char? c2)
    {
        if (Value <= 0xFFFF)
        {
            c1 = (char)Value;
            c2 = null;
            return;
        }

        int v = unchecked((int)Value - 0x10000);
        c1 = (char)(Math.DivRem(v, 0x400, out int rem) + 0xD800);
        c2 = (char)(rem + 0xDC00);
    }

    public bool Equals(CodePoint other) => Value == other.Value;

    public override bool Equals(object? obj) => obj is CodePoint other && Equals(other);

    public override int GetHashCode() => (int)Value;
}
