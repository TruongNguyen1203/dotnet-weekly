namespace WebApplication1;

public class LoggingDelegatingHandler : DelegatingHandler
{
    private readonly ILogger<LoggingDelegatingHandler> _logger;
    private readonly Random _random = new();

    public LoggingDelegatingHandler(ILogger<LoggingDelegatingHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Before HTTP request");

            if (_random.NextDouble() < 0.5)
            {
                throw new HttpRequestException();
            }
            var result = await base.SendAsync(request, cancellationToken);
            result.EnsureSuccessStatusCode();
            _logger.LogInformation("After HTTP request");
            return result;

        }
        catch (Exception e)
        {
            _logger.LogError(e, "HTTP request failed");
            throw;
        }
    }
}