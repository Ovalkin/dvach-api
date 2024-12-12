namespace DvachApi.Common.Models;

public class Thread : Post
{
    public int FileCount { get; set; }
    public int PostCount { get; set; }
    public List<Post>? Posts { get; set; }
}