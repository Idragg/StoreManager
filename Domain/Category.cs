using System.ComponentModel.DataAnnotations;

namespace StoreManager.BL.Domain;

public class Category
{
    public int Id { get; set; }
    [Required]
    [RegularExpression("^[A-Z].*")]
    public string Name { get; set; }
    [Required]
    [Length(10, 100)]
    public string Description { get; set; }
    [Required]
    public ICollection<Product> Products { get; set; }
}