public class OrderProcessor
{
    private List<IProduct> currentProduct;

    public OrderProcessor(List<IProduct> product)
    {
        currentProduct = product;
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

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
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
}
