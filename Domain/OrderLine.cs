using System.ComponentModel.DataAnnotations;

namespace StoreManager.BL.Domain;

public class OrderLine
{
    [Range(0, int.MaxValue)] public int Quantity { get; set; }
    [Range(1, int.MaxValue)] public double UnitPrice { get; set; }

    [Required]
    public Order Order { get; set; }
    [Required]
    public Product Product { get; set; }
}