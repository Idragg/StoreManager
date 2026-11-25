using StoreManager.DAL;
using StoreManager.DAL.BL;
using StoreManager.UI.CA;

Console.OutputEncoding = System.Text.Encoding.UTF8;
RepositoryInMemory repositoryInMemory = new RepositoryInMemory();
Manager manager = new Manager(repositoryInMemory);
var consoleUi = new ConsoleUi(manager);
consoleUi.Run();
