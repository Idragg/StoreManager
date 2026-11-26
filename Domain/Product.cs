using System.ComponentModel.DataAnnotations;

namespace StoreManager.BL.Domain;

public class Product
{
    public int Id { get; set; }

    [Required]
    [RegularExpression("^[A-Z].*")]
    public string Name { get; set; }

    [Required] public Category Category { get; set; }
    public ICollection<StoreProduct> StoreProducts { get; set; }
    [Required] public ICollection<Supplier> Suppliers { get; set; }
    [Required] public ICollection<OrderLine> OrderLines { get; set; }
}