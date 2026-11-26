using System.ComponentModel.DataAnnotations;

namespace StoreManager.BL.Domain;

public class Order
{
    public int Id { get; set; }
    public DateOnly OrderDate { get; set; }
    public DateOnly ExpectedDeliveryDate { get; set; }

    [Required]
    [EnumDataType(typeof(OrderStatus))]
    public OrderStatus OrderStatus { get; set; }

    [Required] public Store Store { get; set; }
    [Required] public Supplier Supplier { get; set; }
    [Required] public ICollection<OrderLine> OrderLines { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        var validationResult = new List<ValidationResult>();

        if (OrderDate > ExpectedDeliveryDate)
        {
            validationResult.Add(new ValidationResult("The expected delivery date cannot be before order date.",
                [nameof(ExpectedDeliveryDate), nameof(OrderDate)]));
        }

        return validationResult;
    }
}