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
            Console.WriteLine("Your choice is: ");
            var input = Console.ReadLine();
            
            parseOk = int.TryParse(input, out choice);
        }

        return choice;
    }

    private void ShowAllProducts()
    {
        foreach (var product in _manager.GetAllProducts())
        {
            Console.WriteLine(product.InfoText());
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
        var price = 0.0;
        switch (ShowPrice())
        {
            case 1:  price = new MeanPrice(_manager).GetPrice();
                Console.WriteLine($"The mean price is: {price}");
                break;
            case 2:  price = new WeightMeanPrice(_manager).GetPrice();
                Console.WriteLine($"The weighted mean price is: {price}");
                break;
        }
        
    }
}