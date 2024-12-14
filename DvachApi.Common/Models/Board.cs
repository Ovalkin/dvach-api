using System.Net.Http.Json;
using System.Text.Json;
using DvachApi.Common.Interfaces;
using DvachApi.Common.Models.Enums;
using Newtonsoft.Json;
using JsonElement = System.Text.Json.JsonElement;

namespace DvachApi.Common.Models;

public class Board
{
    public string Category { get; set; } = null!;
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<Thread> Threads { get; set; } = new();
    public static List<Board> GetBoards()
    {
        var responseMessage = GetApiEndpoints.GetBoards();
        List<Board> boards = new();
        string content = responseMessage.Result.Content.ReadAsStringAsync().Result;
        using (var doc = JsonDocument.Parse(content))
        {
            JsonElement root = doc.RootElement;
            foreach (var element in root.EnumerateArray())
            {
                boards.Add(new Board
                {
                    Category = element.GetProperty("category").GetString()!,
                    Id = element.GetProperty("id").GetString()!,
                    Name = element.GetProperty("name").GetString()!,
                });
            }
        }
        return boards;
    }

    public void LoadThreads()
    {
        List<Thread> threads = new();
        var responseMessage = GetApiEndpoints.GetThreads(Id);
        string content = responseMessage.Result.Content.ReadAsStringAsync().Result;
        using (var doc = JsonDocument.Parse(content))
        {
            JsonElement root = doc.RootElement;
            JsonElement threadsJson = root.GetProperty("threads");
            foreach (var element in threadsJson.EnumerateArray())
            {
                List<Attachment> files = new();
                foreach (var file in element.GetProperty("files").EnumerateArray())
                {
                    files.Add(new Attachment
                    {
                        Name = file.GetProperty("name").GetString()!,
                        Path = file.GetProperty("path").GetString()!,
                    });
                }
                threads.Add(new Thread
                {
                    BoardId = Id,
                    FileCount = element.GetProperty("files_count").GetInt32(),
                    PostCount =  element.GetProperty("posts_count").GetInt32(),
                    Num =  element.GetProperty("num").GetInt32(),
                    Timestamp =  element.GetProperty("timestamp").GetInt32(),
                    Date = element.GetProperty("date").GetString()!,
                    Name = element.GetProperty("name").GetString()!,
                    Email = element.GetProperty("email").GetString(),
                    Subject = element.GetProperty("subject").GetString(),
                    Comment = element.GetProperty("comment").GetString()!,
                    Files = files
                });
            }
            Threads = threads;
        }
    }
}