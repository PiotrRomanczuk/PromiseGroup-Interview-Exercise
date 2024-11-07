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
        var serviceProvider = new ServiceCollection()
            .AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=./DB/app.db"))
            .AddTransient<DataBaseHandler>()
            .BuildServiceProvider();

        _dbContext = serviceProvider.GetService<AppDbContext>()!;
        DbHelper = new DataBaseHandler(_dbContext);

        OrderProcessor = new OrderProcessor(CurrentOrder, DbHelper);

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