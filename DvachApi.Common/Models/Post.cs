namespace DvachApi.Common.Models;

public class Post
{
    public int Num { get; set; }
    public int Timestamp { get; set; }
    public string Date { get; set; } = null!;
    public bool Op { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Trip { get; set; }
    public string? Subject { get; set; }
    public string Comment { get; set; } = null!;
    public List<Attachment>? Files { get; set; }
    public bool Banned { get; set; }
    public bool Closed { get; set; }
    public bool Endless { get; set; }
    public int? Lasthit { get; set; }
    public bool Sticky { get; set; }
    public string? Tags { get; set; }
    public int Parent { get; set; }
    public int? Likes { get; set; }
    public int? Dislikes { get; set; }
}