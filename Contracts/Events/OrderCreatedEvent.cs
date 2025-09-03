namespace Contracts.Events;

public record OrderCreatedEvent
(
    Guid IdOrder,
    DateTime DateCreated
);