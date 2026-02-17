using Raiqub.Generators.EnumUtilities.Models;
using Raiqub.Generators.InterpolationCodeWriter;

namespace Raiqub.Generators.EnumUtilities.CodeWriters.Extensions;

public sealed class ExtensionsInterlockedBlock : ICodeWriterModule<EnumToGenerate>
{
    public bool CanGenerateFor(EnumToGenerate model) =>
        (model.SelectedGenerators & SelectedGenerators.MainGenerator) != 0
        && model.InterlockedUnderlyingType is not null;

    public void Write(SourceTextWriter writer, EnumToGenerate model)
    {
        var underlyingType = model.InterlockedUnderlyingType!;
        if (model.IsFlags)
        {
            WriteInterlockedAnd(writer, model, underlyingType);
            writer.WriteLine();
            WriteInterlockedOr(writer, model, underlyingType);
        }
        else
        {
            WriteInterlockedAdd(writer, model, underlyingType);
            writer.WriteLine();
            WriteInterlockedDecrement(writer, model, underlyingType);
            writer.WriteLine();
            WriteInterlockedIncrement(writer, model, underlyingType);
        }

        writer.WriteLine();
        WriteInterlockedCompareExchange(writer, model, underlyingType);
        writer.WriteLine();
        WriteInterlockedExchange(writer, model, underlyingType);

        if (underlyingType == "long")
        {
            writer.WriteLine();
            WriteInterlockedRead(writer, model, underlyingType);
        }
    }

    private static void WriteInterlockedAnd(SourceTextWriter writer, EnumToGenerate model, string underlyingType)
    {
        writer.WriteLine(
            $$"""
            /// <summary>Bitwise "ands" two enumerations and replaces the first value with the result, as an atomic operation.</summary>
            /// <param name="location">A variable containing the first value to be combined.</param>
            /// <param name="value">The value to be combined with the value at <paramref name="location" />.</param>
            /// <returns>The original value in <paramref name="location" />.</returns>
            public static {{model.RefName}} InterlockedAnd(this ref {{model.RefName}} location, {{model.RefName}} value)
            {
                ref {{underlyingType}} locationRaw = ref Unsafe.As<{{model.RefName}}, {{underlyingType}}>(ref location);
                {{underlyingType}} resultRaw = Interlocked.And(ref locationRaw, Unsafe.As<{{model.RefName}}, {{underlyingType}}>(ref value));
                return Unsafe.As<{{underlyingType}}, {{model.RefName}}>(ref resultRaw);
            }
            """
        );
    }

    private static void WriteInterlockedOr(SourceTextWriter writer, EnumToGenerate model, string underlyingType)
    {
        writer.WriteLine(
            $$"""
            /// <summary>Bitwise "ors" two enumerations and replaces the first value with the result, as an atomic operation.</summary>
            /// <param name="location">A variable containing the first value to be combined.</param>
            /// <param name="value">The value to be combined with the value at <paramref name="location" />.</param>
            /// <returns>The original value in <paramref name="location" />.</returns>
            public static {{model.RefName}} InterlockedOr(this ref {{model.RefName}} location, {{model.RefName}} value)
            {
                ref {{underlyingType}} locationRaw = ref Unsafe.As<{{model.RefName}}, {{underlyingType}}>(ref location);
                {{underlyingType}} resultRaw = Interlocked.Or(ref locationRaw, Unsafe.As<{{model.RefName}}, {{underlyingType}}>(ref value));
                return Unsafe.As<{{underlyingType}}, {{model.RefName}}>(ref resultRaw);
            }
            """
        );
    }

    private static void WriteInterlockedAdd(SourceTextWriter writer, EnumToGenerate model, string underlyingType)
    {
        writer.WriteLine(
            $$"""
            /// <summary>Adds two enumerations and replaces the first integer with the sum, as an atomic operation.</summary>
            /// <param name="location">A variable containing the first value to be added.</param>
            /// <param name="value">The value to be added to the enumeration at <paramref name="location" />.</param>
            /// <returns>The new value that was stored at <paramref name="location" /> by this operation.</returns>
            public static {{model.RefName}} InterlockedAdd(this ref {{model.RefName}} location, {{underlyingType}} value)
            {
                ref {{underlyingType}} locationRaw = ref Unsafe.As<{{model.RefName}}, {{underlyingType}}>(ref location);
                {{underlyingType}} resultRaw = Interlocked.Add(ref locationRaw, value);
                return Unsafe.As<{{underlyingType}}, {{model.RefName}}>(ref resultRaw);
            }
            """
        );
    }

    private static void WriteInterlockedDecrement(SourceTextWriter writer, EnumToGenerate model, string underlyingType)
    {
        writer.WriteLine(
            $$"""
            /// <summary>Decrements enumeration and stores the result, as an atomic operation.</summary>
            /// <param name="location">The variable whose value is to be decremented.</param>
            /// <returns>The value of the variable immediately after the decrement operation finished.</returns>
            public static {{model.RefName}} InterlockedDecrement(this ref {{model.RefName}} location)
            {
                ref {{underlyingType}} locationRaw = ref Unsafe.As<{{model.RefName}}, {{underlyingType}}>(ref location);
                {{underlyingType}} resultRaw = Interlocked.Decrement(ref locationRaw);
                return Unsafe.As<{{underlyingType}}, {{model.RefName}}>(ref resultRaw);
            }
            """
        );
    }

    private static void WriteInterlockedIncrement(SourceTextWriter writer, EnumToGenerate model, string underlyingType)
    {
        writer.WriteLine(
            $$"""
            /// <summary>Increments enumeration and stores the result, as an atomic operation.</summary>
            /// <param name="location">The variable whose value is to be incremented.</param>
            /// <returns>The value of the variable immediately after the increment operation finished.</returns>
            public static {{model.RefName}} InterlockedIncrement(this ref {{model.RefName}} location)
            {
                ref {{underlyingType}} locationRaw = ref Unsafe.As<{{model.RefName}}, {{underlyingType}}>(ref location);
                {{underlyingType}} resultRaw = Interlocked.Increment(ref locationRaw);
                return Unsafe.As<{{underlyingType}}, {{model.RefName}}>(ref resultRaw);
            }
            """
        );
    }

    private static void WriteInterlockedCompareExchange(
        SourceTextWriter writer,
        EnumToGenerate model,
        string underlyingType
    )
    {
        writer.WriteLine(
            $$"""
            /// <summary>Compares two enumerations for equality and, if they are equal, replaces the first value.</summary>
            /// <param name="location">The destination, whose value is compared with <paramref name="comparand" /> and possibly replaced.</param>
            /// <param name="value">The value that replaces the destination value if the comparison results in equality.</param>
            /// <param name="comparand">The value that is compared to the value at <paramref name="location" />.</param>
            /// <returns>The original value in <paramref name="location" />.</returns>
            public static {{model.RefName}} InterlockedCompareExchange(this ref {{model.RefName}} location, {{model.RefName}} value, {{model.RefName}} comparand)
            {
                ref {{underlyingType}} locationRaw = ref Unsafe.As<{{model.RefName}}, {{underlyingType}}>(ref location);
                {{underlyingType}} resultRaw = Interlocked.CompareExchange(ref locationRaw, Unsafe.As<{{model.RefName}}, {{underlyingType}}>(ref value), Unsafe.As<{{model.RefName}}, {{underlyingType}}>(ref comparand));
                return Unsafe.As<{{underlyingType}}, {{model.RefName}}>(ref resultRaw);
            }
            """
        );
    }

    private static void WriteInterlockedExchange(SourceTextWriter writer, EnumToGenerate model, string underlyingType)
    {
        writer.WriteLine(
            $$"""
            /// <summary>Sets an enumeration value to a specified value and returns the original value, as an atomic operation.</summary>
            /// <param name="location">The variable to set to the specified value.</param>
            /// <param name="value">The value to which the <paramref name="location" /> parameter is set.</param>
            /// <returns>The original value of <paramref name="location" />.</returns>
            public static {{model.RefName}} InterlockedExchange(this ref {{model.RefName}} location, {{model.RefName}} value)
            {
                ref {{underlyingType}} locationRaw = ref Unsafe.As<{{model.RefName}}, {{underlyingType}}>(ref location);
                {{underlyingType}} resultRaw = Interlocked.Exchange(ref locationRaw, Unsafe.As<{{model.RefName}}, {{underlyingType}}>(ref value));
                return Unsafe.As<{{underlyingType}}, {{model.RefName}}>(ref resultRaw);
            }
            """
        );
    }

    private static void WriteInterlockedRead(SourceTextWriter writer, EnumToGenerate model, string underlyingType)
    {
        writer.WriteLine(
            $$"""
            /// <summary>Returns a 64-bit enumeration value, loaded as an atomic operation.</summary>
            /// <param name="location">The 64-bit enumeration value to be loaded.</param>
            /// <returns>The loaded value.</returns>
            public static {{model.RefName}} InterlockedRead(this ref {{model.RefName}} location)
            {
                ref {{underlyingType}} locationRaw = ref Unsafe.As<{{model.RefName}}, {{underlyingType}}>(ref location);
                {{underlyingType}} resultRaw = Interlocked.Read(ref locationRaw);
                return Unsafe.As<{{underlyingType}}, {{model.RefName}}>(ref resultRaw);
            }
            """
        );
    }
}
