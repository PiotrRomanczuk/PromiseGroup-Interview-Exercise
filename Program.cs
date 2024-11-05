using Microsoft.Data.Sqlite;

class Program
{
    static List<IProduct> CurrentOrder = new List<IProduct>();

    static void Main(string[] args)
    {
        OrderProcessor orderProcessor = new OrderProcessor(CurrentOrder);



        while (true)
        {
            Console.Clear();

            Console.WriteLine("Welcome to the online store!");

            string connectionString = "Data Source=./DB/hello.db";
            var dbHelper = new DatabaseHelper(connectionString);

            // Ensure the user table exists
            dbHelper.EnsureUserTableExists();

            string id = "some_default_value"; // Initialize with a default value or get it from user input

            // Get the user name by id
            string name = dbHelper.GetUserNameById(id);

            if (name != null)
            {
                Console.WriteLine($"Hello, {name}!");
            }
            else
            {
                Console.WriteLine("User not found.");
            }



            DateTime date = DateTime.Now;
            Console.WriteLine("\nToday is {0:d} at {0:T}.", date);

            decimal totalOrderPrice = CurrentOrder.Sum(product => product.Price);
            decimal totalDiscount = orderProcessor.GetDiscount();
            decimal totalOrderPriceAfterDiscount = totalOrderPrice - totalDiscount;

            Console.WriteLine("\nYour current order price equals: " + totalOrderPrice.ToString("C"));
            Console.WriteLine("Your current order discount: " + totalDiscount.ToString("C"));
            Console.WriteLine("Your current order price after discount: " + totalOrderPriceAfterDiscount.ToString("C"));

            Console.WriteLine("\n1) Add product");
            Console.WriteLine("2) Delete product");
            Console.WriteLine("3) Check products in order");
            Console.WriteLine("4) Check previous orders");
            Console.WriteLine("5) Quit Program");

            Console.WriteLine("\nPlease enter a number (1-5):");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                UserInputHandler.ProcessUserInput(number, orderProcessor);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.ReadKey();
            }
        }
    }
}
