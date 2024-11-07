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
        var user = new UserModel { UserId = int.Parse(id), Name = name, Email = email };
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public List<UserModel> GetAllUsers()
    {
        var usersString = string.Join(", ", _context.Users.Select(u => u.Name));
        Console.WriteLine(usersString);
        return _context.Users.ToList();
    }

    public string? GetUserNameById(string id)
    {
        if (int.TryParse(id, out int userId))
        {
            var user = _context.Users.SingleOrDefault(u => u.UserId == userId);
            return user?.Name;
        }
        else
        {
            return null;
        }
    }
    public void CreateOrder(int userId, List<IProduct> products)
    {
        try
        {
            var orderProductsString = string.Join(", ", products.Select(p => p.Name));
            Console.WriteLine($"orderProducts: {orderProductsString}");

            // Create ProductModel instances from Product objects
            var orderProducts = products.Select(p => new ProductModel
            {
                Product = (Product)p,
                Quantity = 1 // Assuming a default quantity of 1 for each product
            }).ToList();

            var order = new OrderModel
            {
                UserId = userId,
                OrderProducts = orderProducts,
                OrderDate = DateTime.Now
            };

            Console.WriteLine($"order: {order}");
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
        }
    }

    public List<OrderModel> GetAllOrders()
    {
        return _context.Orders.Include(o => o.OrderProducts).ToList();
    }
}