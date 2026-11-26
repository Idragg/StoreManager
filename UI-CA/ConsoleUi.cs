using StoreManager.BL.Domain;
using StoreManager.DAL.BL;
using StoreManager.UI.CA.extensions;

namespace StoreManager.UI.CA;

public class ConsoleUi
{
    private readonly IManager _manager;
    public ConsoleUi(IManager manager)
    {
        _manager = manager;
    }

    public void Run()
    {
        var quit = false;

        while (!quit)
        {

            switch (ReadChoices())
            {
                case 0:
                    Console.WriteLine("Quiting...");
                    quit = true;
                    break;
                case 1:
                    ShowAllProducts();
                    break;
                case 2:
                    ChosenPrice();
                    break;
            }
        }
    }

    private int ReadChoices()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("==========================");
        Console.WriteLine("0) Quit");
        Console.WriteLine("1) Show all products");
        Console.WriteLine("2) Show all products price");
        
        
        bool parseOk = false;
        int choice = 0;
        while (!parseOk)
        {
            Console.Write("Your choice is: ");
            var input = Console.ReadLine();
            
            parseOk = int.TryParse(input, out choice);
        }

        return choice;
    }

    private void ShowAllProducts()
    {
        foreach (var product in _manager.GetAllProducts())
        {
            Console.WriteLine($"{product.Id} - {product.InfoText()}");
        }
    }
    
    private void ShowAllCategories()
    {
        foreach (var category in _manager.GetAllCategories())
        {
            Console.WriteLine($"{category.Id} - {category.Name}");
        }
    }

    private int ShowPrice()
    {
        bool parseOk = false;
        var choice = 0;
        
        while (!parseOk)
        {
            Console.WriteLine("Choos");
            Console.WriteLine("======================");
            Console.WriteLine("1) Mean Price");
            Console.WriteLine("2) Weighted Mean Price");
            Console.WriteLine("======================");
            Console.Write("Chosen: ");
            var input = Console.ReadLine();
            parseOk = int.TryParse(input, out choice);
        }
        return choice;
    }

    private void ChosenPrice()
    {
        bool parseOk = false;
        int choiceId = 0;
        while (!parseOk)
        {
            ShowAllCategories();
            Console.Write("Chosen ID of category if you give no Id then its price of all products: ");

            parseOk = int.TryParse(Console.ReadLine(), out choiceId);

            if (!parseOk)
            {
                Console.WriteLine("Invalid input.");
            }
        }

        Category? category = null;

        if (choiceId != 0)
        {
            category = _manager.GetAllCategories()
                .FirstOrDefault(c => c.Id == choiceId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }
        }

        switch (ShowPrice())
        {
            case 1:
                var meanPrice = new MeanPrice(_manager).GetPrice(category);
                Console.WriteLine($"The mean price is: {meanPrice}");
                break;

            case 2:
                var weightMeanPrice = new WeightMeanPrice(_manager).GetPrice(category);
                Console.WriteLine($"The weighted mean price is: {weightMeanPrice}");
                break;

            default:
                Console.WriteLine("Invalid price strategy.");
                break;
        }
    }
}