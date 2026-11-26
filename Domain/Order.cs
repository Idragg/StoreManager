using System.ComponentModel.DataAnnotations;

namespace StoreManager.BL.Domain;

public class Order
{
    public int Id { get; set; }
    public DateOnly OrderDate { get; set; }
    public DateOnly DateOnly { get; set; }
    public Status Status { get; set; }

    [Required]
    [EnumDataType(typeof(Status))]
    public Store Store { get; set; }

    [Required] public Supplier Supplier { get; set; }
    [Required] public ICollection<OrderLine> OrderLines { get; set; }
}