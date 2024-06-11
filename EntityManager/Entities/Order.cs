namespace EntityManager.Entities;

public class Order : BaseEntity<int>
{
    public DateTime ?Time { get; set; }

    public ICollection<OrderProduct> Products { get; set; }
}