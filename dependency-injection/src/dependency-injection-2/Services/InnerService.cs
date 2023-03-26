public enum ServiceState {
    Init,
    Set,
    Running,
    Stopped
}

public class InnerService
{
    public ServiceState State { get; set; } = ServiceState.Init;
    public readonly ILogger<InnerService> _logger;

    public InnerService(ILogger<InnerService> logger)
    {
        _logger = logger;
    }

    public string GetState()
    {
        _logger.LogInformation("Call State {State}", State);
        return $"State: {State}";
    }
}