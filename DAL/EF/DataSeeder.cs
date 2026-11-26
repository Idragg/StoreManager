using StoreManager.BL.Domain;

namespace StoreManager.DAL.EF;

public class DataSeeder
{
    public static void Seed(StoreManagerDbContext context)
    {
        // Categories
        var fluids = new Category
        {
            Name = "Fluids",
            Description = "Products that are liquid.",
            Products = new List<Product>()
        };

        var food = new Category
        {
            Name = "Food",
            Description = "Products that can be eaten.",
            Products = new List<Product>()
        };

        var electronics = new Category
        {
            Name = "Electronics",
            Description = "Electronic devices and accessories.",
            Products = new List<Product>()
        };

        // Products
        var milk = new Product
        {
            Name = "Milk",
            Category = fluids,
            StoreProducts = new List<StoreProduct>()
        };

        var orangeJuice = new Product
        {
            Name = "Orange Juice",
            Category = fluids,
            StoreProducts = new List<StoreProduct>()
        };

        var water = new Product
        {
            Name = "Water",
            Category = fluids,
            StoreProducts = new List<StoreProduct>()
        };

        var bread = new Product
        {
            Name = "Bread",
            Category = food,
            StoreProducts = new List<StoreProduct>()
        };

        var pasta = new Product
        {
            Name = "Pasta",
            Category = food,
            StoreProducts = new List<StoreProduct>()
        };

        var rice = new Product
        {
            Name = "Rice",
            Category = food,
            StoreProducts = new List<StoreProduct>()
        };

        var headphones = new Product
        {
            Name = "Headphones",
            Category = electronics,
            StoreProducts = new List<StoreProduct>()
        };

        var keyboard = new Product
        {
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
            Name = "Antwerp",
            StoreProducts = new List<StoreProduct>(),
            Categories = new List<Category>()
        };

        var storeBrussels = new Store
        {
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
        context.Add(fluids);
        context.Add(food);
        context.Add(electronics);

        context.Add(milk);
        context.Add(orangeJuice);
        context.Add(water);
        context.Add(bread);
        context.Add(pasta);
        context.Add(rice);
        context.Add(headphones);
        context.Add(keyboard);

        context.Add(storeAntwerp);
        context.Add(storeBrussels);

        context.SaveChanges();
        context.ChangeTracker.Clear();
    }
}