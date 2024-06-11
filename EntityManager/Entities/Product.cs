namespace EntityManager.Entities;

public class Product : BaseEntity<int>
{
    public string Name { get; set; }

    public ICollection<OrderProduct> Orders { get; set; }

}