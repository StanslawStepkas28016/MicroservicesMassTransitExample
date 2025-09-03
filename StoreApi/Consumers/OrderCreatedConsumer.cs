using System.Text.Json;
using Contracts;
using Contracts.Events;
using MassTransit;

namespace ConsumerApi.Consumers;

public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
{
    private readonly ILogger<OrderCreatedConsumer> _logger;

    public OrderCreatedConsumer(ILogger<OrderCreatedConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        // Log the event data.
        _logger.LogInformation
        (
            "An order with the IdOrder {IdOrder} has just been created at {DateCreated}.",
            context.Message.IdOrder,
            context.Message.DateCreated
        );

        // Simulate other operations...
        await Task.Delay(2000);
    }
}