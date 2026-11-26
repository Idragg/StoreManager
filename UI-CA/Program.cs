using Microsoft.EntityFrameworkCore;
using StoreManager.DAL.BL;
using StoreManager.DAL.EF;
using StoreManager.UI.CA;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var dbOptionsBuilder
    = new DbContextOptionsBuilder<StoreManagerDbContext>();
dbOptionsBuilder.UseSqlite("Data Source=StoreManager.db");
var context = new StoreManagerDbContext(dbOptionsBuilder.Options);

if (context.CreateDatabase(true)) DataSeeder.Seed(context);


// composition root
var repository = new Repository(context);
var manager = new Manager(repository);
var consoleUi = new ConsoleUi(manager);
consoleUi.Run();

