class ListOfProducts
{
    static List<IProduct> products = new List<IProduct>();
    static readonly List<IProduct> predefinedProducts = new List<IProduct>
    {

        new Product(1, "Laptop", 2500),
        new Product(2, "Keyboard", 120),
        new Product(3, "Mouse", 90),
        new Product(4, "Display", 1000),
        new Product(5, "Debugging Duck", 66)

    };

    public static List<IProduct> GetProducts()
    {
        return predefinedProducts;
    }

    public int ListLength()
    {
        return predefinedProducts.Count;
    }

}