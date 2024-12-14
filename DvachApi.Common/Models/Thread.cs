using System.Text.Json;

namespace DvachApi.Common.Models;

public class Thread : Post
{
    public string BoardId { get; set; } = null!;
    public int FileCount { get; set; }
    public int PostCount { get; set; }
    public List<Post> Posts { get; set; } = new();

    public void LoadPosts()
    {
        List<Post> posts = new();
        var responseMessage = GetApiEndpoints.GetPosts(BoardId, Num);
        string content = responseMessage.Result.Content.ReadAsStringAsync().Result;
        using (var doc = JsonDocument.Parse(content))
        {
            JsonElement root = doc.RootElement;
            JsonElement threadsJson = root.GetProperty("threads");
            var thread = threadsJson.EnumerateArray().First();

            foreach (var post in thread.GetProperty("posts").EnumerateArray())
            {
                List<Attachment> files = new();

                var filesJson = post.GetProperty("files");
                if (JsonValueKind.Null != filesJson.ValueKind)
                {
                    foreach (var file in post.GetProperty("files").EnumerateArray())
                    {
                        files.Add(new Attachment
                        {
                            Name = file.GetProperty("name").GetString()!,
                            Path = file.GetProperty("path").GetString()!,
                        });
                    }
                }
                
                posts.Add(new Post
                {
                    Num = post.GetProperty("num").GetInt32(),
                    Timestamp = post.GetProperty("timestamp").GetInt32(),
                    Date = post.GetProperty("date").GetString()!,
                    Name = post.GetProperty("name").GetString()!,
                    Email = post.GetProperty("email").GetString(),
                    Subject = post.GetProperty("subject").GetString(),
                    Comment = post.GetProperty("comment").GetString()!,
                    Files = files
                });
            }
        }
        Posts = posts;
    }
}