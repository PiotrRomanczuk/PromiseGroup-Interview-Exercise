using System.Diagnostics;
class Program
{
    static List<IProduct> CurrentOrder = new List<IProduct>();
    static void Main(string[] args)
    {
        while (true)
        {


            Console.WriteLine("Your current order price equals: " + CurrentOrder.ToString());

            // System.Collections.Generic.List`1[IProduct]

            // DateTime date = new DateTime();

            // Console.WriteLine("\nToday is {0:d} at {0:T}.", date);
            // Console.Write("\nPress any key to continue... ");
            // Console.ReadLine();


            Console.WriteLine("Your current order discount: " + "CurrentOrderDiscount");
            Console.WriteLine("Discount comes form: + RuleOfDiscount");


            Console.WriteLine("1) Add product");
            Console.WriteLine("2) Delete product");
            Console.WriteLine("3) Quit Program");

            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You entered: " + number);

            if (number == 1)
            {
                Debugger.Break();

                AddProduct();

                // Console.WriteLine("You added a product");
            }
            else if (number == 2)
            {
                Debugger.Break();
                Console.WriteLine("You deleted a product");
            }
            else if (number == 3)
            {
                Debugger.Break();
                Environment.Exit(0);
            }
            else
            {
                Debugger.Break();
                Console.WriteLine("You entered an invalid number");
            }

            static void AddProduct()
            {
                Console.WriteLine("What product do you want to add?");

                ListOfProducts listOfProducts = new ListOfProducts();
                for (int i = 0; i < listOfProducts.ListLength(); i++)
                {
                    var product = ListOfProducts.GetProducts()[i];
                    Console.WriteLine($"{i + 1}. {product.Name} price: {product.Price}PLN");
                }

                int productNumber = Convert.ToInt32(Console.ReadLine());

                if (productNumber > 0 && productNumber <= listOfProducts.ListLength())
                {
                    CurrentOrder.Add(ListOfProducts.GetProducts()[productNumber - 1]);
                    Console.WriteLine("You added a product");
                }
                else
                {
                    Console.WriteLine("You entered an invalid number");
                }

            }
        }
    }
}