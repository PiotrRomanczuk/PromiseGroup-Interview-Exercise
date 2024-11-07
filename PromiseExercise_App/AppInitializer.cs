using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class AppInitializer
{
    public static List<IProduct> CurrentOrder = new List<IProduct>();
    public static OrderProcessor OrderProcessor = null!;
    public static DataBaseHandler DbHelper = null!;
    private static AppDbContext _dbContext = null!;

    public static void Initialize()
    {
        // Ensure the directory exists
        var projectDirectory = AppContext.BaseDirectory;
        // Get out project directory form the bin folder
        projectDirectory = Path.GetFullPath(Path.Combine(projectDirectory, "../../../"));

        var dbDirectory = Path.Combine(projectDirectory, "DB");
        if (!Directory.Exists(dbDirectory))
        {
            Directory.CreateDirectory(dbDirectory);
        }
        // Use an absolute path for the database file
        var dbPath = Path.Combine(dbDirectory, "app.db");

        // Create a new instance of the ServiceCollection class, which is used to register services for dependency injection.
        var serviceProvider = new ServiceCollection()
            // Register the AppDbContext with the dependency injection container.
            // Configure it to use SQLite with the specified database file path.
            .AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={dbPath}"))
            // Register the DataBaseHandler class as a transient service.
            // Transient services are created each time they are requested.
            .AddTransient<DataBaseHandler>()
            // Build the service provider, which is used to resolve services.
            .BuildServiceProvider();

        // Retrieve an instance of AppDbContext from the service provider.
        // The exclamation mark (!) is used to indicate that the value is not null.
        _dbContext = serviceProvider.GetService<AppDbContext>()!;

        // Create a new instance of DataBaseHandler, passing in the AppDbContext instance.
        DbHelper = new DataBaseHandler(_dbContext);

        // Create a new instance of OrderProcessor, passing in the current order list and the DataBaseHandler instance.
        OrderProcessor = new OrderProcessor(CurrentOrder, DbHelper);

        // Ensure that the order table exists in the database by calling the CreateOrderTable method on the DataBaseHandler instance.
        DbHelper.CreateOrderTable();
    }

    public static AppDbContext GetDbContext()
    {
        return _dbContext;
    }

    public static DataBaseHandler GetDbHelper()
    {
        return DbHelper;
    }
}