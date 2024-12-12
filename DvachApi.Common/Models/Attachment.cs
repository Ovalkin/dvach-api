using DvachApi.Common.Models.Enums;

namespace DvachApi.Common.Models;

public class Attachment
{
    public FileType Type { get; set; }
    public bool Nsfw { get; set; }
    public int Size { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string DisplayName { get; set; }
    public string FullName { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Md5 { get; set; }
    public string Thumbnail { get; set; }
    public int TnWidth { get; set; }
    public int TnHeight { get; set; }
    public string Duration { get; set; }
    public int DurationSecs { get; set; }
}