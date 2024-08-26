using Raiqub.Generators.EnumUtilities;

namespace EnumUtilities.Benchmark.Models;

[Flags]
[EnumGenerator]
public enum PermissionsRaiqub : uint
{
    None = 0,
    Read = 1 << 0,
    Write = 1 << 1,
    Execute = 1 << 2,
    Delete = 1 << 3,
    Modify = 1 << 4,
    Create = 1 << 5,
    View = 1 << 6,
    Share = 1 << 7,
    Copy = 1 << 8,
    Move = 1 << 9,
    Rename = 1 << 10,
    Download = 1 << 11,
    Upload = 1 << 12,
    Sync = 1 << 13,
    Archive = 1 << 14,
    Restore = 1 << 15,
    Print = 1 << 16,
    Preview = 1 << 17,
    Search = 1 << 18,
    Tag = 1 << 19,
    Annotate = 1 << 20,
    Comment = 1 << 21,
    Approve = 1 << 22,
    Reject = 1 << 23,
    Publish = 1 << 24,
    Subscribe = 1 << 25,
    Unsubscribe = 1 << 26,
    Manage = 1 << 27,
    Edit = 1 << 28,
    Lock = 1 << 29,
    Unlock = 1 << 30,
    FullControl = 1u << 31
}
