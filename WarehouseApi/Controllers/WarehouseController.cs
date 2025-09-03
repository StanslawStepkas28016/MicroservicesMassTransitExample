using Microsoft.AspNetCore.Mvc;
using ProducerApi.Dtos;
using ProducerApi.Model;
using ProducerApi.Services;

namespace ProducerApi.Controllers;

[ApiController]
[Route("api/warehouse")]
public class WarehouseController : ControllerBase
{
    private readonly ILogger<WarehouseController> _logger;
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(ILogger<WarehouseController> logger, IWarehouseService warehouseService)
    {
        _logger = logger;
        _warehouseService = warehouseService;
    }

    [HttpPost("order")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest createOrderRequest,
        CancellationToken cancellationToken)
    {
        Order order = await _warehouseService.CreateOrder(createOrderRequest, cancellationToken);

        _logger.LogInformation
            ("An order with the Id of {IdOrder} has been created at {DateCreated}", order.IdOrder, order.DateCreated);

        return Ok(order);
    }
}