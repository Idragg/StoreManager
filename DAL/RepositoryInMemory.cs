using StoreManager.Domain;

namespace StoreManager.DAL;

public class RepositoryInMemory : IRepository
{
    private readonly ICollection<Product> _products;
    private readonly ICollection<Store> _stores;
    private readonly ICollection<Category> _categories;

    public RepositoryInMemory()
    {
        _categories = new List<Category>();
        _products = new List<Product>();
        _stores = new List<Store>();
        Seed();
    }

    private void Seed()
    {
        // Categories
        var fluids = new Category
        {
            Id = 1,
            Name = "Fluids",
            Description = "Products that are liquid.",
            Products = new List<Product>()
        };

        var food = new Category
        {
            Id = 2,
            Name = "Food",
            Description = "Products that can be eaten.",
            Products = new List<Product>()
        };

        var electronics = new Category
        {
            Id = 3,
            Name = "Electronics",
            Description = "Electronic devices and accessories.",
            Products = new List<Product>()
        };

        // Products
        var milk = new Product
        {
            Id = 1,
            Name = "Milk",
            Category = fluids,
            Price = 2.30,
            Stock = 100
        };

        var orangeJuice = new Product
        {
            Id = 2,
            Name = "Orange Juice",
            Category = fluids,
            Price = 2.75,
            Stock = 50
        };

        var water = new Product
        {
            Id = 3,
            Name = "Water",
            Category = fluids,
            Price = 1.20,
            Stock = 200
        };

        var bread = new Product
        {
            Id = 4,
            Name = "Bread",
            Category = food,
            Price = 2.50,
            Stock = 40
        };

        var pasta = new Product
        {
            Id = 5,
            Name = "Pasta",
            Category = food,
            Price = 1.80,
            Stock = 75
        };

        var rice = new Product
        {
            Id = 6,
            Name = "Rice",
            Category = food,
            Price = 3.20,
            Stock = 60
        };

        var headphones = new Product
        {
            Id = 7,
            Name = "Headphones",
            Category = electronics,
            Price = 49.99,
            Stock = 15
        };

        var keyboard = new Product
        {
            Id = 8,
            Name = "Keyboard",
            Category = electronics,
            Price = 34.99,
            Stock = 25
        };

        // Category relationships
        fluids.Products.Add(milk);
        fluids.Products.Add(orangeJuice);
        fluids.Products.Add(water);

        food.Products.Add(bread);
        food.Products.Add(pasta);
        food.Products.Add(rice);

        electronics.Products.Add(headphones);
        electronics.Products.Add(keyboard);

        // Stores
        var storeAntwerp = new Store
        {
            Id = 1,
            Name = "Antwerp",
            Products = new List<Product>(),
            Categories = new List<Category>()
        };

        var storeBrussels = new Store
        {
            Id = 2,
            Name = "Brussels",
            Products = new List<Product>(),
            Categories = new List<Category>()
        };

        // Antwerp stock
        storeAntwerp.Products.Add(milk);
        storeAntwerp.Products.Add(orangeJuice);
        storeAntwerp.Products.Add(bread);
        storeAntwerp.Products.Add(pasta);
        storeAntwerp.Products.Add(headphones);

        // Brussels stock
        storeBrussels.Products.Add(water);
        storeBrussels.Products.Add(bread);
        storeBrussels.Products.Add(rice);
        storeBrussels.Products.Add(keyboard);
        storeBrussels.Products.Add(headphones);

        // Store categories
        storeAntwerp.Categories.Add(fluids);
        storeAntwerp.Categories.Add(food);
        storeAntwerp.Categories.Add(electronics);

        storeBrussels.Categories.Add(fluids);
        storeBrussels.Categories.Add(food);
        storeBrussels.Categories.Add(electronics);

        // Add to repository collections
        _categories.Add(fluids);
        _categories.Add(food);
        _categories.Add(electronics);

        _products.Add(milk);
        _products.Add(orangeJuice);
        _products.Add(water);
        _products.Add(bread);
        _products.Add(pasta);
        _products.Add(rice);
        _products.Add(headphones);
        _products.Add(keyboard);

        _stores.Add(storeAntwerp);
        _stores.Add(storeBrussels);
    }

    public IEnumerable<Product> ReadAllProducts()
    {
        return _products;
    }
}