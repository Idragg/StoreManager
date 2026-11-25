namespace StoreManager.Domain;

public class Store
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<Category> Categories { get; set; }
}