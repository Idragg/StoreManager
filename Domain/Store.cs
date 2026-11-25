using System.ComponentModel.DataAnnotations;

namespace StoreManager.Domain;

public class Store
{
    public int Id { get; set; }
    [Required]
    [RegularExpression("^[A-Z].*")]
    public string Name { get; set; }
    [Required]
    public ICollection<Product> Products { get; set; }
    [Required]
    public ICollection<Category> Categories { get; set; }
}