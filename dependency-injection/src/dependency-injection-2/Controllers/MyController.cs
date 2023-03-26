using Microsoft.AspNetCore.Mvc;

namespace dependency_injection_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MyController : ControllerBase
{
    private readonly ILogger<MyController> _logger;
    private readonly OuterService _outerService;
    private readonly InnerService _innerService;

    public MyController(ILogger<MyController> logger, OuterService outerService, InnerService innerService)
    {
        _logger = logger;
        _outerService = outerService;
        _innerService = innerService;
    }
    
    [HttpGet]
    public string Get()
    {
        string result = string.Empty;
        result = $"{result}{ _innerService.GetState()}{Environment.NewLine}";
        _outerService.SetInnerService(ServiceState.Set);
        result = $"{result}{ _innerService.GetState()}{Environment.NewLine}";
        _outerService.SetInnerService(ServiceState.Running);
        result = $"{result}{ _innerService.GetState()}{Environment.NewLine}";
        return result;
    }
}
