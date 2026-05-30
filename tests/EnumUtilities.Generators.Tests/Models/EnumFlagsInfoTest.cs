using Raiqub.Generators.EnumUtilities.Generators.Tests.Common;
using Raiqub.Generators.EnumUtilities.Models;

namespace Raiqub.Generators.EnumUtilities.Generators.Tests.Models;

public class EnumFlagsInfoTest
{
    [Fact]
    public async Task BitValues_ReturnsOnlySingleBitValues()
    {
        var flagsInfo = await CreateFlagsInfo(
            """
            using System;
            using Raiqub.Generators.EnumUtilities;

            [Flags]
            [EnumGenerator]
            public enum Permissions
            {
                None = 0,
                Read = 1,
                Write = 2,
                Execute = 4,
                ReadWrite = Read | Write
            }
            """
        );

        var result = flagsInfo.BitValues.Select(x => x.MemberName).ToArray();

        Assert.Equal(["Read", "Write", "Execute"], result);
    }

    [Fact]
    public async Task InvertedCompositeValues_ReturnsCompositeValuesInDescendingOrder()
    {
        var flagsInfo = await CreateFlagsInfo(
            """
            using System;
            using Raiqub.Generators.EnumUtilities;

            [Flags]
            [EnumGenerator]
            public enum Permissions
            {
                None = 0,
                Read = 1,
                Write = 2,
                Execute = 4,
                ReadWrite = Read | Write,
                WriteExecute = Write | Execute,
                All = Read | Write | Execute
            }
            """
        );

        var result = flagsInfo.InvertedCompositeValues.Select(x => x.MemberName).ToArray();

        Assert.Equal(["All", "WriteExecute", "ReadWrite"], result);
    }

    [Theory]
    [MemberData(nameof(HasFewCombinationsCases))]
    public async Task HasFewCombinations_ReturnsExpectedValue(string source, bool expected)
    {
        var flagsInfo = await CreateFlagsInfo(source);

        Assert.Equal(expected, flagsInfo.HasFewCombinations);
    }

    [Theory]
    [MemberData(nameof(IsAllSingleBitsDefinedCases))]
    public async Task IsAllSingleBitsDefined_ReturnsExpectedValue(string source, bool expected)
    {
        var flagsInfo = await CreateFlagsInfo(source);

        Assert.Equal(expected, flagsInfo.IsAllSingleBitsDefined);
    }

    [Theory]
    [MemberData(nameof(IsAllBitsDefinedCases))]
    public async Task IsAllBitsDefined_ReturnsExpectedValue(string source, bool expected)
    {
        var flagsInfo = await CreateFlagsInfo(source);

        Assert.Equal(expected, flagsInfo.IsAllBitsDefined);
    }

    [Theory]
    [MemberData(nameof(ValidFlagsMaskCases))]
    public async Task ValidFlagsMask_ReturnsExpectedMasks(
        string source,
        object expectedMask,
        ulong expectedUnsignedMask,
        long expectedSignedMask
    )
    {
        var flagsInfo = await CreateFlagsInfo(source);

        Assert.IsType(expectedMask.GetType(), flagsInfo.ValidFlagsMask);
        Assert.Equal(expectedMask, flagsInfo.ValidFlagsMask);
        Assert.Equal(expectedUnsignedMask, flagsInfo.ValidFlagsMaskUnsigned);
        Assert.Equal(expectedSignedMask, flagsInfo.ValidFlagsMaskSigned);
    }

    [Fact]
    public async Task GetMatchingValues_WithExactCompositeValue_ReturnsCompositeMember()
    {
        var flagsInfo = await CreateFlagsInfo(
            """
            using System;
            using Raiqub.Generators.EnumUtilities;

            [Flags]
            [EnumGenerator]
            public enum Permissions
            {
                None = 0,
                Read = 1,
                Write = 2,
                Execute = 4,
                ReadWrite = Read | Write
            }
            """
        );

        var result = flagsInfo.GetMatchingValues(3).Select(x => x.MemberName).ToArray();

        Assert.Equal(["ReadWrite"], result);
    }

    [Fact]
    public async Task GetMatchingValues_WithOverlappingCompositeFlags_ReturnsOnlyUnconsumedMatches()
    {
        var flagsInfo = await CreateFlagsInfo(
            """
            using System;
            using Raiqub.Generators.EnumUtilities;

            [Flags]
            [EnumGenerator]
            public enum Permissions
            {
                None = 0,
                One = 1,
                Two = 2,
                Three = One | Two,
                Four = 4,
                Six = Two | Four
            }
            """
        );

        var result = flagsInfo.GetMatchingValues(7).Select(x => x.MemberName).ToArray();

        Assert.Equal(["One", "Six"], result);
    }

    [Fact]
    public async Task GetMatchingValues_WithValueThatCannotBeFullyDecomposed_ReturnsEmpty()
    {
        var flagsInfo = await CreateFlagsInfo(
            """
            using System;
            using Raiqub.Generators.EnumUtilities;

            [Flags]
            [EnumGenerator]
            public enum Permissions
            {
                None = 0,
                Read = 1,
                Execute = 4
            }
            """
        );

        var result = flagsInfo.GetMatchingValues(2).Select(x => x.MemberName).ToArray();

        Assert.Empty(result);
    }

    public static TheoryData<string, bool> HasFewCombinationsCases =>
        new()
        {
            {
                """
                    using System;
                    using Raiqub.Generators.EnumUtilities;

                    [Flags]
                    [EnumGenerator]
                    public enum SmallFlags : uint
                    {
                        Bit0 = 1u << 0,
                        Bit7 = 1u << 7
                    }
                    """,
                true
            },
            {
                """
                    using System;
                    using Raiqub.Generators.EnumUtilities;

                    [Flags]
                    [EnumGenerator]
                    public enum LargeFlags : uint
                    {
                        Bit0 = 1u << 0,
                        Bit8 = 1u << 8
                    }
                    """,
                false
            },
        };

    public static TheoryData<string, bool> IsAllSingleBitsDefinedCases =>
        new()
        {
            {
                """
                    using System;
                    using Raiqub.Generators.EnumUtilities;

                    [Flags]
                    [EnumGenerator]
                    public enum FullBitSet
                    {
                        A = 1,
                        B = 2,
                        C = 4
                    }
                    """,
                true
            },
            {
                """
                    using System;
                    using Raiqub.Generators.EnumUtilities;

                    [Flags]
                    [EnumGenerator]
                    public enum MissingBit
                    {
                        A = 1,
                        C = 4,
                        All = A | C
                    }
                    """,
                false
            },
        };

    public static TheoryData<string, bool> IsAllBitsDefinedCases =>
        new()
        {
            {
                """
                    using System;
                    using Raiqub.Generators.EnumUtilities;

                    [Flags]
                    [EnumGenerator]
                    public enum PartialByte : byte
                    {
                        A = 1,
                        B = 2,
                        C = 4
                    }
                    """,
                false
            },
            {
                """
                    using System;
                    using Raiqub.Generators.EnumUtilities;

                    [Flags]
                    [EnumGenerator]
                    public enum FullByte : byte
                    {
                        All = byte.MaxValue
                    }
                    """,
                true
            },
            {
                """
                    using System;
                    using Raiqub.Generators.EnumUtilities;

                    [Flags]
                    [EnumGenerator]
                    public enum FullSignedInt
                    {
                        All = -1
                    }
                    """,
                true
            },
        };

    public static TheoryData<string, object, ulong, long> ValidFlagsMaskCases =>
        new()
        {
            {
                """
                    using System;
                    using Raiqub.Generators.EnumUtilities;

                    [Flags]
                    [EnumGenerator]
                    public enum Permissions : byte
                    {
                        Read = 1,
                        Write = 2,
                        Execute = 4
                    }
                    """,
                (byte)7,
                7UL,
                7L
            },
            {
                """
                    using System;
                    using Raiqub.Generators.EnumUtilities;

                    [Flags]
                    [EnumGenerator]
                    public enum Permissions : ulong
                    {
                        Read = 1UL,
                        Write = 2UL,
                        Execute = 4UL,
                        All = Read | Write | Execute
                    }
                    """,
                7UL,
                7UL,
                7L
            },
            {
                """
                    using System;
                    using Raiqub.Generators.EnumUtilities;

                    [Flags]
                    [EnumGenerator]
                    public enum SignedPermissions : int
                    {
                        Read = 1,
                        Write = 2,
                        Execute = 4
                    }
                    """,
                7,
                7UL,
                7L
            },
        };

    private static async Task<EnumFlagsInfo> CreateFlagsInfo(string source)
    {
        var symbol = await CompilationSymbolFactory.GetEnumSymbol(source);
        var model = EnumToGenerate.FromSymbol(symbol) ?? throw new InvalidOperationException("Enum model not found");

        return model.FlagsInfo ?? throw new InvalidOperationException("Flags info not found");
    }
}
