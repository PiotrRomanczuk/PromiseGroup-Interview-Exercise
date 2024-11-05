class Program
{
    static List<IProduct> CurrentOrder = new List<IProduct>();

    static void Main(string[] args)
    {
        OrderProcessor orderProcessor = new OrderProcessor(CurrentOrder);
        while (true)
        {
            Console.Clear();

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
            Console.WriteLine("4) Quit Program");

            Console.WriteLine("\nPlease enter a number (1-4):");

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
