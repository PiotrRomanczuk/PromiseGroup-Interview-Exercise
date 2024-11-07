using Microsoft.EntityFrameworkCore;

public class DataBaseHandler
{
    private readonly AppDbContext _context;

    public DataBaseHandler(AppDbContext context)
    {
        _context = context;
    }

    public void EnsureUserTableExists()
    {
        _context.Database.EnsureCreated();
    }

    public void CreateOrderTable()
    {
        _context.Database.EnsureCreated();
    }

    public void CreateUser(string id, string name, string? email = null)
    {
        var user = new UserModel { UserId = id, Name = name, Email = email };
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public string? GetUserNameById(string id)
    {
        var user = _context.Users.SingleOrDefault(u => u.UserId == id);
        return user?.Name;
    }

    public void CreateOrder(int userId, List<IProduct> products)
    {
        var orderProducts = products.Cast<ProductModel>().ToList();
        var order = new OrderModel { UserId = userId, OrderProducts = orderProducts, OrderDate = DateTime.Now };
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public List<OrderModel> GetAllOrders()
    {
        return _context.Orders.Include(o => o.OrderProducts).ToList();
    }
}