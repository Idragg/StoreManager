using System.ComponentModel.DataAnnotations;

namespace StoreManager.BL.Domain;

public class Store
{
    public int Id { get; set; }
    [Required]
    [RegularExpression("^[A-Z].*")]
    public string Name { get; set; }
    [Required]
    public ICollection<StoreProduct> StoreProducts { get; set; }
    [Required]
    public ICollection<Category> Categories { get; set; }
}