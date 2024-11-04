public class OrderItem
{
    public IProduct Product { get; set; }
    public int Quantity { get; set; }

    public OrderItem(IProduct product, int quantity)
    {
        Product = product;
        Quantity = quantity;

    }

    public decimal GetTotalPrice()
    {
        return Product.Price * Quantity;
    }
}