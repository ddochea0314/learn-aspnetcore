public class OuterService
{
    public readonly InnerService _innerService;
    public readonly ILogger<OuterService> _logger;

    public OuterService(
        ILogger<OuterService> logger,
        InnerService myService2)
    {
        _logger = logger;
        _innerService = myService2;        
    }

    public void SetInnerService(ServiceState state)
    {
        _innerService.State = state;
        _logger.LogInformation(_innerService.GetState());
    }
}