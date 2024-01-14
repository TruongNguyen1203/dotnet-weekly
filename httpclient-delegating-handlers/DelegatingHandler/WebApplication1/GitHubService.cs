namespace WebApplication1;

public class GitHubService()
{
    private readonly HttpClient _httpClient;

    public GitHubService(HttpClient httpClient) : this()
    {
        _httpClient = httpClient;
    }
    public async Task<object?> GetByUserName(string username)
    {
       string url = $"users/{username}";
       var result = await _httpClient.GetFromJsonAsync<object>(url);
       return result;
    }
}