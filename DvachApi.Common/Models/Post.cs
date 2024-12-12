namespace DvachApi.Common.Models;

public class Post
{
    public int Num { get; set; }
    public int Timestamp { get; set; }
    public string Date { get; set; }= null!;
    public bool Op { get; set; }
    public string Name { get; set; }= null!;
    public string? Email { get; set; }
    public string? Subject { get; set; }
    public string Comment { get; set; }= null!;
    public List<Attachment>? Files { get; set; }
}