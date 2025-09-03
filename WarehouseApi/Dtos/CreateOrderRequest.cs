namespace ProducerApi.Dtos;

public sealed class CreateOrderRequest
{
    public string Name { get; set; } = String.Empty;
    public int Quantity { get; set; }
}