using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using StoreManager.BL.Domain;

namespace StoreManager.DAL.EF;

public class Repository : IRepository
{
    private readonly StoreManagerDbContext _context;

    public Repository(StoreManagerDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> ReadAllProducts()
    {
        return _context.Products
            .Include(p => p.Category)
            .ToList();
    }

    public IEnumerable<Category> ReadAllCategories()
    {
        return _context.Categories
            .ToList();
    }

    public IEnumerable<StoreProduct> ReadAllStoreProducts()
    {
        return _context.StoreProducts.
            Include(sp => sp.Product)
            .ToList();
    }
    
    private void Validate(object o)
    {
        // Validator.ValidateObject(o, new ValidationContext(o), true);

        var validationResults = new List<ValidationResult>();
        var validationSuccessful = Validator.TryValidateObject(o, new ValidationContext(o), validationResults, true);
        if (!validationSuccessful)
        {
            var message = "";
            foreach (var result in validationResults)
            {
                if (message.Length != 0)
                {
                    message += "\n";
                }

                message += result.ErrorMessage;
            }

            throw new ValidationException(message);
        }
    }
}