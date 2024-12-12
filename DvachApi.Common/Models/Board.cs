using DvachApi.Common.Models.Enums;
using Newtonsoft.Json;

namespace DvachApi.Common.Models;

public class Board
{
    public string Category { get; set; } = null!;
    public List<FileType> FileTypes { get; set; } = null!;
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<Thread>? Threads { get; set; }
}