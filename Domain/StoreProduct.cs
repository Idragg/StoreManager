using System.ComponentModel.DataAnnotations;

namespace StoreManager.BL.Domain;

public class StoreProduct
{
    
    public Store Store { get; set; }
    
    public Product Product { get; set; }
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
    [Range(0, int.MaxValue)]
    public double SellingPrice { get; set; }
}