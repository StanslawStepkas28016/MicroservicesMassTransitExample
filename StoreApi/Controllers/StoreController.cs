using Microsoft.AspNetCore.Mvc;

namespace ConsumerApi.Controllers;

[ApiController]
[Route("api/store")]
public class StoreController : ControllerBase
{
    private readonly ILogger<StoreController> _logger;

    public StoreController(ILogger<StoreController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public IActionResult Get()
    {
        return Ok();
    }
}