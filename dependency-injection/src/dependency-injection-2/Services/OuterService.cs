public class OuterService
{
    public readonly InnerService _innerService;
    public readonly ILogger<OuterService> _logger;

    public OuterService(
        ILogger<OuterService> logger,
        InnerService innerService)
    {
        _logger = logger;
        _innerService = innerService;        
    }

    public void SetInnerService(ServiceState state)
    {
        _logger.LogInformation("Set innserService State {State}", state);
        _innerService.State = state;
    }
}