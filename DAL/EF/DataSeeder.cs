using Microsoft.EntityFrameworkCore;
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
            StoreProducts = new List<StoreProduct>(),
            Suppliers = new List<Supplier>(),
            OrderLines = new List<OrderLine>()
        };

        var orangeJuice = new Product
        {
            Name = "Orange Juice",
            Category = fluids,
            StoreProducts = new List<StoreProduct>(),
            Suppliers = new List<Supplier>(),
            OrderLines = new List<OrderLine>()
        };

        var water = new Product
        {
            Name = "Water",
            Category = fluids,
            StoreProducts = new List<StoreProduct>(),
            Suppliers = new List<Supplier>(),
            OrderLines = new List<OrderLine>()
        };

        var bread = new Product
        {
            Name = "Bread",
            Category = food,
            StoreProducts = new List<StoreProduct>(),
            Suppliers = new List<Supplier>(),
            OrderLines = new List<OrderLine>()
        };

        var pasta = new Product
        {
            Name = "Pasta",
            Category = food,
            StoreProducts = new List<StoreProduct>(),
            Suppliers = new List<Supplier>(),
            OrderLines = new List<OrderLine>()
        };

        var rice = new Product
        {
            Name = "Rice",
            Category = food,
            StoreProducts = new List<StoreProduct>(),
            Suppliers = new List<Supplier>(),
            OrderLines = new List<OrderLine>()
        };

        var headphones = new Product
        {
            Name = "Headphones",
            Category = electronics,
            StoreProducts = new List<StoreProduct>(),
            Suppliers = new List<Supplier>(),
            OrderLines = new List<OrderLine>()
        };

        var keyboard = new Product
        {
            Name = "Keyboard",
            Category = electronics,
            StoreProducts = new List<StoreProduct>(),
            Suppliers = new List<Supplier>(),
            OrderLines = new List<OrderLine>()
        };

        var mouse = new Product
        {
            Name = "Wireless Mouse",
            Category = electronics,
            StoreProducts = new List<StoreProduct>(),
            Suppliers = new List<Supplier>(),
            OrderLines = new List<OrderLine>()
        };

        // Category relationships
        foreach (var product in new[] { milk, orangeJuice, water })
            fluids.Products.Add(product);

        foreach (var product in new[] { bread, pasta, rice })
            food.Products.Add(product);

        foreach (var product in new[] { headphones, keyboard, mouse })
            electronics.Products.Add(product);

        // Stores
        var storeAntwerp = new Store
        {
            Name = "Antwerp",
            StoreProducts = new List<StoreProduct>(),
            Categories = new List<Category>(),
            Orders = new List<Order>(),
            Employees = new List<Employee>()
        };

        var storeBrussels = new Store
        {
            Name = "Brussels",
            StoreProducts = new List<StoreProduct>(),
            Categories = new List<Category>(),
            Orders = new List<Order>(),
            Employees = new List<Employee>()
        };

        var storeGhent = new Store
        {
            Name = "Ghent",
            StoreProducts = new List<StoreProduct>(),
            Categories = new List<Category>(),
            Orders = new List<Order>(),
            Employees = new List<Employee>()
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
            new StoreProduct { Store = storeAntwerp, Product = mouse, Stock = 30, SellingPrice = 24.99 },

            // Brussels
            new StoreProduct { Store = storeBrussels, Product = milk, Stock = 45, SellingPrice = 2.50 },
            new StoreProduct { Store = storeBrussels, Product = water, Stock = 200, SellingPrice = 1.20 },
            new StoreProduct { Store = storeBrussels, Product = bread, Stock = 30, SellingPrice = 2.60 },
            new StoreProduct { Store = storeBrussels, Product = rice, Stock = 60, SellingPrice = 3.20 },
            new StoreProduct { Store = storeBrussels, Product = keyboard, Stock = 25, SellingPrice = 34.99 },
            new StoreProduct { Store = storeBrussels, Product = mouse, Stock = 18, SellingPrice = 27.50 },

            // Ghent
            new StoreProduct { Store = storeGhent, Product = orangeJuice, Stock = 35, SellingPrice = 2.60 },
            new StoreProduct { Store = storeGhent, Product = water, Stock = 150, SellingPrice = 0.99 },
            new StoreProduct { Store = storeGhent, Product = pasta, Stock = 20, SellingPrice = 2.10 },
            new StoreProduct { Store = storeGhent, Product = rice, Stock = 80, SellingPrice = 2.95 },
            new StoreProduct { Store = storeGhent, Product = headphones, Stock = 10, SellingPrice = 54.99 },
            new StoreProduct { Store = storeGhent, Product = keyboard, Stock = 12, SellingPrice = 39.99 }
        };

        foreach (var storeProduct in storeProducts)
        {
            storeProduct.Store.StoreProducts.Add(storeProduct);
            storeProduct.Product.StoreProducts.Add(storeProduct);
        }

        // Store categories
        foreach (var category in new[] { fluids, food, electronics })
        {
            storeAntwerp.Categories.Add(category);
            storeBrussels.Categories.Add(category);
            storeGhent.Categories.Add(category);
        }

        // Employees
        var employee1 = new Employee
        {
            FirstName = "Jan",
            LastName = "Peeters",
            Email = "jan.peeters@storemanager.be",
            Store = storeAntwerp
        };

        var employee2 = new Employee
        {
            FirstName = "Sarah",
            LastName = "Janssens",
            Email = "sarah.janssens@storemanager.be",
            Store = storeAntwerp
        };

        var employee3 = new Employee
        {
            FirstName = "Tom",
            LastName = "De Smet",
            Email = "tom.desmet@storemanager.be",
            Store = storeBrussels
        };

        var employee4 = new Employee
        {
            FirstName = "Emma",
            LastName = "Vermeulen",
            Email = "emma.vermeulen@storemanager.be",
            Store = storeGhent
        };

        storeAntwerp.Employees.Add(employee1);
        storeAntwerp.Employees.Add(employee2);
        storeBrussels.Employees.Add(employee3);
        storeGhent.Employees.Add(employee4);

        // Suppliers
        var supplierFresh = new Supplier
        {
            Name = "FreshSupply",
            Email = "info@freshsupply.be",
            PhoneNumber = "+32 3 555 10 10",
            Products = new List<Product>()
        };

        var supplierFood = new Supplier
        {
            Name = "FoodWholesale",
            Email = "orders@foodwholesale.be",
            PhoneNumber = "+32 9 555 20 20",
            Products = new List<Product>()
        };

        var supplierTech = new Supplier
        {
            Name = "TechDistribution",
            Email = "sales@techdistribution.be",
            PhoneNumber = "+32 2 555 30 30",
            Products = new List<Product>()
        };

        // Supplier - Product relationships
        foreach (var product in new[] { milk, orangeJuice, water })
            supplierFresh.Products.Add(product);

        foreach (var product in new[] { bread, pasta, rice, milk })
            supplierFood.Products.Add(product);

        foreach (var product in new[] { headphones, keyboard, mouse })
            supplierTech.Products.Add(product);

        milk.Suppliers.Add(supplierFresh);
        milk.Suppliers.Add(supplierFood);

        orangeJuice.Suppliers.Add(supplierFresh);
        water.Suppliers.Add(supplierFresh);

        bread.Suppliers.Add(supplierFood);
        pasta.Suppliers.Add(supplierFood);
        rice.Suppliers.Add(supplierFood);

        headphones.Suppliers.Add(supplierTech);
        keyboard.Suppliers.Add(supplierTech);
        mouse.Suppliers.Add(supplierTech);

        // Orders
        var order1 = new Order
        {
            OrderDate = new DateOnly(2026, 11, 20),
            ExpectedDeliveryDate = new DateOnly(2026, 11, 27),
            OrderStatus = OrderStatus.Pending,
            Store = storeAntwerp,
            Supplier = supplierFresh,
            OrderLines = new List<OrderLine>()
        };

        var order2 = new Order
        {
            OrderDate = new DateOnly(2026, 11, 18),
            ExpectedDeliveryDate = new DateOnly(2026, 11, 21),
            OrderStatus = OrderStatus.Delivered,
            Store = storeAntwerp,
            Supplier = supplierFood,
            OrderLines = new List<OrderLine>()
        };

        var order3 = new Order
        {
            OrderDate = new DateOnly(2026, 11, 22),
            ExpectedDeliveryDate = new DateOnly(2026, 11, 29),
            OrderStatus = OrderStatus.Processing,
            Store = storeBrussels,
            Supplier = supplierFresh,
            OrderLines = new List<OrderLine>()
        };

        var order4 = new Order
        {
            OrderDate = new DateOnly(2026, 11, 24),
            ExpectedDeliveryDate = new DateOnly(2026, 11, 26),
            OrderStatus = OrderStatus.Shipped,
            Store = storeBrussels,
            Supplier = supplierTech,
            OrderLines = new List<OrderLine>()
        };

        var order5 = new Order
        {
            OrderDate = new DateOnly(2026, 11, 23),
            ExpectedDeliveryDate = new DateOnly(2026, 11, 30),
            OrderStatus = OrderStatus.Pending,
            Store = storeGhent,
            Supplier = supplierFood,
            OrderLines = new List<OrderLine>()
        };

        var order6 = new Order
        {
            OrderDate = new DateOnly(2026, 11, 19),
            ExpectedDeliveryDate = new DateOnly(2026, 11, 22),
            OrderStatus = OrderStatus.Delivered,
            Store = storeGhent,
            Supplier = supplierFresh,
            OrderLines = new List<OrderLine>()
        };

        // OrderLines
        var orderLines = new List<OrderLine>
        {
            // Order 1 - Antwerp - FreshSupply
            new OrderLine { Order = order1, Product = milk, Quantity = 50, UnitPrice = 1.70 },
            new OrderLine { Order = order1, Product = orangeJuice, Quantity = 30, UnitPrice = 1.80 },
            new OrderLine { Order = order1, Product = water, Quantity = 20, UnitPrice = 0.50 },

            // Order 2 - Antwerp - FoodWholesale
            new OrderLine { Order = order2, Product = pasta, Quantity = 100, UnitPrice = 1.20 },
            new OrderLine { Order = order2, Product = rice, Quantity = 60, UnitPrice = 2.10 },
            new OrderLine { Order = order2, Product = bread, Quantity = 30, UnitPrice = 1.80 },

            // Order 3 - Brussels - FreshSupply
            new OrderLine { Order = order3, Product = water, Quantity = 120, UnitPrice = 0.65 },
            new OrderLine { Order = order3, Product = orangeJuice, Quantity = 40, UnitPrice = 1.90 },
            new OrderLine { Order = order3, Product = milk, Quantity = 25, UnitPrice = 1.75 },

            // Order 4 - Brussels - TechDistribution
            new OrderLine { Order = order4, Product = keyboard, Quantity = 10, UnitPrice = 28.00 },
            new OrderLine { Order = order4, Product = mouse, Quantity = 15, UnitPrice = 18.00 },
            new OrderLine { Order = order4, Product = headphones, Quantity = 5, UnitPrice = 38.00 },

            // Order 5 - Ghent - FoodWholesale
            new OrderLine { Order = order5, Product = pasta, Quantity = 70, UnitPrice = 1.30 },
            new OrderLine { Order = order5, Product = rice, Quantity = 90, UnitPrice = 2.00 },
            new OrderLine { Order = order5, Product = bread, Quantity = 25, UnitPrice = 1.85 },

            // Order 6 - Ghent - FreshSupply
            new OrderLine { Order = order6, Product = rice, Quantity = 90, UnitPrice = 2.00 },
            new OrderLine { Order = order6, Product = water, Quantity = 200, UnitPrice = 0.60 }
        };

        foreach (var orderLine in orderLines)
        {
            orderLine.Order.OrderLines.Add(orderLine);
            orderLine.Product.OrderLines.Add(orderLine);
        }

        // Store - Order relationships
        storeAntwerp.Orders.Add(order1);
        storeAntwerp.Orders.Add(order2);

        storeBrussels.Orders.Add(order3);
        storeBrussels.Orders.Add(order4);

        storeGhent.Orders.Add(order5);
        storeGhent.Orders.Add(order6);

        // Add to context
        context.AddRange(
            fluids, food, electronics,
            milk, orangeJuice, water, bread, pasta, rice,
            headphones, keyboard, mouse,
            storeAntwerp, storeBrussels, storeGhent,
            supplierFresh, supplierFood, supplierTech,
            employee1, employee2, employee3, employee4,
            order1, order2, order3, order4, order5, order6
        );

        context.SaveChanges();
        context.ChangeTracker.Clear();
    }
}