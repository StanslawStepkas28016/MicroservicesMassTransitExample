using Contracts;
using Contracts.Events;
using MassTransit;
using ProducerApi.Dtos;
using ProducerApi.Model;

namespace ProducerApi.Services;

public class WarehouseService : IWarehouseService
{
    private readonly IPublishEndpoint _publishEndpoint;

    public WarehouseService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Order> CreateOrder(CreateOrderRequest createOrderRequest, CancellationToken cancellationToken)
    {
        // Create the object.
        Order order = new Order
        {
            IdOrder = Guid.NewGuid(),
            DateCreated = DateTime.UtcNow,
            Name = createOrderRequest.Name,
            Quantity = createOrderRequest.Quantity
        };

        // Simulate db operations...
        await Task.Delay(1000, cancellationToken);

        // Publish the event.
        await _publishEndpoint.Publish
        (
            new OrderCreatedEvent
            (
                order.IdOrder,
                order.DateCreated
            ), cancellationToken
        );

        return order;
    }
}