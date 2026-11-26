using System.ComponentModel.DataAnnotations;

namespace StoreManager.BL.Domain;

public class Supplier
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    public string Email { get; set; }
    [Required]
    [RegularExpression(@"^(?:\+32|0)\d{8,9}$")]
    public string PhoneNumber { get; set; }

    [Required]
    public ICollection<Order> Orders { get; set; }
    [Required] public ICollection<Product> Products { get; set; }
}