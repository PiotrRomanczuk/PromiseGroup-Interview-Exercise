public interface IProduct
{
    string Name { get; set; }
    decimal Price { get; set; }
}


public class Product : IProduct
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
