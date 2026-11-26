using StoreManager.BL.Domain;

namespace StoreManager.DAL;

public class RepositoryInMemory : IRepository
{
    private readonly ICollection<Product> _products;
    private readonly ICollection<Store> _stores;
    private readonly ICollection<Category> _categories;
    private readonly ICollection<StoreProduct> _storeProducts;
    private readonly ICollection<Order> _orders;

    public RepositoryInMemory()
    {
        _categories = new List<Category>();
        _products = new List<Product>();
        _stores = new List<Store>();
        _storeProducts = new List<StoreProduct>();
        _orders = new List<Order>();
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
            StoreProducts = new List<StoreProduct>()
        };

        var orangeJuice = new Product
        {
            Id = 2,
            Name = "Orange Juice",
            Category = fluids,
            StoreProducts = new List<StoreProduct>()
        };

        var water = new Product
        {
            Id = 3,
            Name = "Water",
            Category = fluids,
            StoreProducts = new List<StoreProduct>()
        };

        var bread = new Product
        {
            Id = 4,
            Name = "Bread",
            Category = food,
            StoreProducts = new List<StoreProduct>()
        };

        var pasta = new Product
        {
            Id = 5,
            Name = "Pasta",
            Category = food,
            StoreProducts = new List<StoreProduct>()
        };

        var rice = new Product
        {
            Id = 6,
            Name = "Rice",
            Category = food,
            StoreProducts = new List<StoreProduct>()
        };

        var headphones = new Product
        {
            Id = 7,
            Name = "Headphones",
            Category = electronics,
            StoreProducts = new List<StoreProduct>()
        };

        var keyboard = new Product
        {
            Id = 8,
            Name = "Keyboard",
            Category = electronics,
            StoreProducts = new List<StoreProduct>()
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
            StoreProducts = new List<StoreProduct>(),
            Categories = new List<Category>()
        };

        var storeBrussels = new Store
        {
            Id = 2,
            Name = "Brussels",
            StoreProducts = new List<StoreProduct>(),
            Categories = new List<Category>()
        };

        // StoreProduct relationships
        var storeProducts = new List<StoreProduct>
        {
            // Antwerp
            new StoreProduct { Store = storeAntwerp, Product = milk, Stock = 100, SellingPrice = 2.30 },
            new StoreProduct { Store = storeAntwerp, Product = orangeJuice, Stock = 50, SellingPrice = 2.75 },
            new StoreProduct { Store = storeAntwerp, Product = bread, Stock = 40, SellingPrice = 2.50 },
            new StoreProduct { Store = storeAntwerp, Product = pasta, Stock = 75, SellingPrice = 1.80 },
            new StoreProduct { Store = storeAntwerp, Product = headphones, Stock = 15, SellingPrice = 49.99 },

            // Brussels
            new StoreProduct { Store = storeBrussels, Product = milk, Stock = 45, SellingPrice = 2.50 },
            new StoreProduct { Store = storeBrussels, Product = water, Stock = 200, SellingPrice = 1.20 },
            new StoreProduct { Store = storeBrussels, Product = bread, Stock = 30, SellingPrice = 2.60 },
            new StoreProduct { Store = storeBrussels, Product = rice, Stock = 60, SellingPrice = 3.20 },
            new StoreProduct { Store = storeBrussels, Product = keyboard, Stock = 25, SellingPrice = 34.99 }
        };

        // Add StoreProduct relationships to both sides
        foreach (var storeProduct in storeProducts)
        {
            storeProduct.Store.StoreProducts.Add(storeProduct);
            storeProduct.Product.StoreProducts.Add(storeProduct);
        }

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

    public IEnumerable<Category> ReadAllCategories()
    {
        return _categories;
    }

    public IEnumerable<StoreProduct> ReadAllStoreProducts()
    {
        return _storeProducts;
    }
}