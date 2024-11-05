public class DiscountCalculator
{
    public static decimal CalculateDiscount(List<IProduct> products)
    {
        decimal totalOrderPrice = products.Sum(product => product.Price);

        if (products.Count > 2)
        {
            decimal minPrice = products.Min(product => product.Price);
            Console.WriteLine(minPrice);
            return minPrice * 0.1m;
        }

        else if (products.Count > 3)
        {
            decimal minPrice = products.Min(product => product.Price);
            Console.WriteLine(minPrice);
            return minPrice * 0.2m;
        }

        else if (totalOrderPrice > 5000)
        {
            return totalOrderPrice * 0.1m;
        }

        else
        {
            return 0;
        }
    }
}