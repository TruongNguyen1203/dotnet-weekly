namespace WebApplication1;

public class GitHubSettings
{
    public static string ConfigurationSection = "GitHubSettings";
    public string AccessToken { get; set; }
    public string UserAgent { get; set; }
}