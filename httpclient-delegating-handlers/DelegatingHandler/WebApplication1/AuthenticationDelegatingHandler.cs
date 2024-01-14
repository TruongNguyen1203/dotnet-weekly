using Microsoft.Extensions.Options;

namespace WebApplication1;

public class AuthenticationDelegatingHandler : DelegatingHandler
{
    private readonly GitHubSettings _gitHubSettings;

    public AuthenticationDelegatingHandler(IOptions<GitHubSettings> gitHubSettings)
    {
        _gitHubSettings = gitHubSettings.Value;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("Authorization", _gitHubSettings.AccessToken);
        request.Headers.Add("User-Agent", _gitHubSettings.UserAgent);
        return base.SendAsync(request, cancellationToken);
    }
}