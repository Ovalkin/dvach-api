﻿using Newtonsoft.Json;

namespace DvachApi.Common.Models;

public class Board
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string Info { get; set; } = null!;
    public string InfoOuter { get; set; } = null!;
    public string ThreadsPerPage { get; set; } = null!;
    public int BumpLimit { get; set; }
    public int MaxPages { get; set; }
    public string DefaultName { get; set; } = null!;
    public bool EnableName { get; set; }
    public bool EnableTrips { get; set; }
    public bool EnableSubject { get; set; }
    public bool EnableSage { get; set; }
    public bool EnableIcons { get; set; }
    public bool EnableFlags { get; set; }
    public bool EnableDices { get; set; }
    public bool EnableShield { get; set; }
    public bool EnableThreadTags { get; set; }
    public bool EnablePosting { get; set; }
    public bool EnableLikes { get; set; }
    public bool EnableOekaki { get; set; }
    public List<string> FileTypes { get; set; } = null!;
    public int MaxComment { get; set; }
    public int MaxFilesSize { get; set; }
    public List<string>? Tags { get; set; }
    public List<Icon>? Icons { get; set; }
    public List<Thread>? Threads { get; set; }

    public static List<Board>? GetBoards()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://2ch.hk/api/mobile/v2/boards");
        var request = new HttpRequestMessage();
        var response = client.Send(request);
        List<Board>? boards = JsonConvert.DeserializeObject<List<Board>>(response.Content.ReadAsStringAsync().Result);
        return boards;
    }
    public Board? LoadThreads()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri($"https://2ch.hk/{Id}/catalog.json");
        var request = new HttpRequestMessage();
        var response = client.Send(request);
        return JsonConvert.DeserializeObject <Board>(response.Content.ReadAsStringAsync().Result);
    }
}