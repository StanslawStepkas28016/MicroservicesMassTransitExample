## MicroservicesMassTransitExample

The following solution presents an example usage of
**MassTransit** in conjunction with **RabbitMQ** for communication between services allowing ease of integration.

- The `WarehouseApi` is a **Producer** which publishes an `OrderCreatedEvent` whenever the `api/warehouse/order` is
  finished executing.


- The `StoreApi` is a **Consumer** which receives the `OrderCreatedEvent` and logs it (this is just for demonstrational
  purposes, in real world scenarios we could perform various operations, e.g. database operations etc.).