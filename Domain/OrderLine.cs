namespace StoreManager.BL.Domain;

public class OrderLine
{
    public int Quantity { get; set; }
    public double UnitsPrice { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }
}