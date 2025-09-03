namespace ProducerApi.Model;

public sealed class Order
{
    public Guid IdOrder { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Quantity { get; set; }
    public DateTime DateCreated { get; set; }
}