using ProducerApi.Dtos;
using ProducerApi.Model;

namespace ProducerApi.Services;

public interface IWarehouseService
{
    Task<Order> CreateOrder(CreateOrderRequest createOrderRequest, CancellationToken cancellationToken);
}