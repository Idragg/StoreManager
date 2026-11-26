using StoreManager.BL.Domain;

namespace StoreManager.DAL.EF;

public class DataSeeder
{

    public static void Seed(StoreManagerDbContext dbContext)
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
            Price = 2.30,
            Stock = 100
        };

        var orangeJuice = new Product
        {
            Name = "Orange Juice",
            Category = fluids,
            Price = 2.75,
            Stock = 50
        };

        var water = new Product
        {
            Name = "Water",
            Category = fluids,
            Price = 1.20,
            Stock = 200
        };

        var bread = new Product
        {
            Name = "Bread",
            Category = food,
            Price = 2.50,
            Stock = 40
        };

        var pasta = new Product
        {
            Name = "Pasta",
            Category = food,
            Price = 1.80,
            Stock = 75
        };

        var rice = new Product
        {
            Name = "Rice",
            Category = food,
            Price = 3.20,
            Stock = 60
        };

        var headphones = new Product
        {
            Name = "Headphones",
            Category = electronics,
            Price = 49.99,
            Stock = 15
        };

        var keyboard = new Product
        {
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
            Name = "Antwerp",
            Products = new List<Product>(),
            Categories = new List<Category>()
        };

        var storeBrussels = new Store
        {
            
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

        dbContext.Categories.Add(fluids);
        dbContext.Categories.Add(food);
        dbContext.Categories.Add(electronics);

        dbContext.Products.Add(milk);
        dbContext.Products.Add(orangeJuice);
        dbContext.Products.Add(water);
        dbContext.Products.Add(bread);
        dbContext.Products.Add(pasta);
        dbContext.Products.Add(rice);
        dbContext.Products.Add(headphones);
        dbContext.Products.Add(keyboard);

        dbContext.Stores.Add(storeBrussels);
        dbContext.Stores.Add(storeAntwerp);
        
        dbContext.SaveChanges();
    }
}