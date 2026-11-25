using System.ComponentModel.DataAnnotations;

namespace StoreManager.Domain;

public class Product
{
    public int Id { get; set; }
    [Required]
    [RegularExpression("^[A-Z].*")]
    public string Name { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public double Price { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
    [Required]
    public Category Category { get; set; }
}