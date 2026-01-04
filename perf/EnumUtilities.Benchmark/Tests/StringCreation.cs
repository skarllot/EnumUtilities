using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace EnumUtilities.Benchmark.Tests;

[MemoryDiagnoser]
[MediumRunJob]
public class StringCreation
{
    private static readonly string[] s_lotrInspiredTexts =
    [
        "In a land far beyond the edges of any map, where the mists of time shroud ancient secrets, a quiet village "
            + "lay nestled among the rolling green hills. Here, in the quaint hamlet of Greenvale, the folk lived simply, "
            + "tending to their fields and flocks, and whispering tales of the great heroes of old. By the hearth, stories "
            + "of Elven lords and Dwarven kings were recited, passed down through countless generations, each tale weaving "
            + "into the fabric of their humble lives. But in the dark corners of the forest, a shadow was stirring, and the "
            + "wind carried with it a faint whisper, a name long forgotten. And so began a journey that would change the "
            + "fate of all who dwelled in that peaceful land.",
        "The great mountains loomed on the horizon like titanic sentinels, their snow-capped peaks piercing the "
            + "heavens. At their feet, the ancient forests spread like a sea of emerald, broken only by the silver thread "
            + "of a mighty river winding its way through the valley. The travelers, weary from their long trek, paused for "
            + "a moment, gazing up at the towering cliffs that seemed to reach up and grasp the very stars themselves. The "
            + "air was cool, filled with the scent of pine and earth, and the distant cry of an eagle echoed through the "
            + "crisp, clear sky. They knew that beyond these mountains lay both danger and destiny, waiting for those bold "
            + "enough to seek it.",
        "In the deep of night, under the gaze of a thousand distant stars, the company made their camp by a quiet "
            + "stream that murmured softly through the undergrowth. The fire crackled warmly, casting flickering shadows "
            + "on the moss-covered stones, and the scent of woodsmoke drifted lazily into the cool night air. They spoke "
            + "little, each lost in their own thoughts, contemplating the path that lay before them. Yet, even in the "
            + "quiet of that moment, there was an unspoken understanding among them — a bond forged not by words, but by "
            + "the shared trials they had endured and the hope that still burned brightly in their hearts. For they knew "
            + "that the dawn would bring new challenges, and the road ahead was long and uncertain.",
    ];

    [Benchmark]
    public string UninitializedString() => string.Create(100, 0, static (_, _) => { });

    [Benchmark]
    public string ZeroedString() => new string('\0', 100);

    [Benchmark]
    public string DirectCreation()
    {
        return string.Create(
            s_lotrInspiredTexts.Sum(x => x.Length),
            s_lotrInspiredTexts.AsSpan(),
            static (span, col) =>
            {
                foreach (var text in col)
                {
                    text.AsSpan().CopyTo(span);
                    span = span.Slice(text.Length);
                }
            }
        );
    }

    [Benchmark]
    public string MemoryMarshalReference()
    {
        var strlen = s_lotrInspiredTexts.Sum(x => x.Length);
        var result = string.Create(strlen, 0, static (_, _) => { });
        var span = MemoryMarshal.CreateSpan(ref MemoryMarshal.GetReference(result.AsSpan()), strlen);
        foreach (var text in s_lotrInspiredTexts)
        {
            text.AsSpan().CopyTo(span);
            span = span.Slice(text.Length);
        }

        return result;
    }

    [Benchmark]
    public unsafe string UnsafePointer()
    {
        var strlen = s_lotrInspiredTexts.Sum(x => x.Length);
        var result = string.Create(strlen, 0, static (_, _) => { });
        fixed (char* ptr = result)
        {
            var span = new Span<char>(ptr, strlen);
            foreach (var text in s_lotrInspiredTexts)
            {
                text.AsSpan().CopyTo(span);
                span = span.Slice(text.Length);
            }
        }

        return result;
    }
}
