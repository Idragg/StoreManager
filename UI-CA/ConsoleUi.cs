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
            }
        }
    }

    private int ReadChoices()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("==========================");
        Console.WriteLine("0) Quit");
        Console.WriteLine("1) Show all products");
        
        
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
}