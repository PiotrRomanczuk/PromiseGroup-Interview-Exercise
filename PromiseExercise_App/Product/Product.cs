public interface IProduct
{
    int ProductId { get; set; }
    string Name { get; set; }
    decimal Price { get; set; }
}


public class Product : IProduct
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(int productId, string name, decimal price)
    {
        ProductId = productId;
        Name = name;
        Price = price;
    }
}
