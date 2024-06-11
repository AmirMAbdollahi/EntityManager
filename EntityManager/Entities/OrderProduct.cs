namespace EntityManager.Entities;

public class OrderProduct
{
    public Order Order { get; set; }
    public Product Product { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
}