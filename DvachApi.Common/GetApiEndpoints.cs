namespace DvachApi.Common;

public static class GetApiEndpoints
{
    private static string _url = "";
    private static readonly HttpClient Client = new();
    public static Task<HttpResponseMessage> GetBoards()
    {
        _url = "https://2ch.hk/api/mobile/v2/boards";
        var response =  Client.GetAsync(_url);
        return response;
    }
    public static Task<HttpResponseMessage> GetThreads(string boardId)
    {
        _url = $"https://2ch.hk/{boardId}/catalog.json";
        var response =  Client.GetAsync(_url);
        return response;
    }

    public static Task<HttpResponseMessage> GetPosts(string boardId, int threadNum)
    {
        _url = $"https://2ch.hk/{boardId}/res/{threadNum}.json";
        var response =  Client.GetAsync(_url);
        return response;
    }
}