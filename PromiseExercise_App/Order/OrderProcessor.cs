public class OrderProcessor
{
    private readonly List<IProduct> currentProduct;
    private readonly DataBaseHandler _dbHandler;

    public OrderProcessor(List<IProduct> currentProduct, DataBaseHandler dbHandler)
    {
        this.currentProduct = currentProduct;
        _dbHandler = dbHandler;
    }
    public decimal GetDiscount()
    {
        return DiscountCalculator.CalculateDiscount(currentProduct);
    }

    public void AddProduct()
    {
        Console.Clear();
        Console.WriteLine("What product do you want to add?");

        ListOfProducts listOfProducts = new ListOfProducts();

        for (int i = 0; i < listOfProducts.ListLength(); i++)
        {
            var product = ListOfProducts.GetProducts()[i];
            Console.WriteLine($"{i + 1}. {product.Name} price: {product.Price}PLN");
        }

        if (int.TryParse(Console.ReadLine(), out int productNumber) &&
            productNumber > 0 && productNumber <= listOfProducts.ListLength())
        {
            currentProduct.Add(ListOfProducts.GetProducts()[productNumber - 1]);
            Console.WriteLine("You added a product.");
        }
        else
        {
            Console.WriteLine("You entered an invalid number.");
        }

        Console.WriteLine("Press a key to go back to the main menu");
    }

    public void DeleteProduct()
    {
        Console.Clear();
        Console.WriteLine("What product do you want to delete?");

        for (int i = 0; i < currentProduct.Count; i++)
        {
            var product = currentProduct[i];
            Console.WriteLine($"{i + 1}. {product.Name} price: {product.Price}PLN");
        }

        if (int.TryParse(Console.ReadLine(), out int productNumber) &&
            productNumber > 0 && productNumber <= currentProduct.Count)
        {
            currentProduct.RemoveAt(productNumber - 1);
            Console.WriteLine("You deleted a product.");
        }
        else
        {
            Console.WriteLine("You entered an invalid number.");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void CheckOrder()
    {
        Console.Clear();
        Console.WriteLine("Your current order contains:");

        for (int i = 0; i < currentProduct.Count; i++)
        {
            var product = currentProduct[i];
            Console.WriteLine($"{i + 1}. {product.Name} price: {product.Price}PLN");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void SaveOrder()
    {

        var allUsers = _dbHandler.GetAllUsers();
        Console.WriteLine($"All users: {allUsers.Count}");


        Console.WriteLine("Please enter your user id:");
        var userID = Console.ReadLine();

        if (userID != null)
        {


            Console.WriteLine($"User found: {userID}");

            Console.WriteLine(string.Join(", ", currentProduct));
            _dbHandler.CreateOrder(int.Parse(userID), currentProduct);

            Console.WriteLine("Order saved.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void CheckAllOrders()
    {
        Console.Clear();
        Console.WriteLine("All orders:");

        var orders = _dbHandler.GetAllOrders();

        foreach (var order in orders)
        {
            Console.WriteLine($"Order id: {order.OrderModelId}, User id: {order.UserId}, Order date: {order.OrderDate}");

            foreach (var product in order.OrderProducts)
            {
                Console.WriteLine($"Product: {product}");
            }
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}