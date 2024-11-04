class ListOfProducts
{
    static List<IProduct> products = new List<IProduct>();

    // Static list of predefined products
    static readonly List<IProduct> predefinedProducts = new List<IProduct>
    {
        //When you define a decimal number in C#,
        //you need to use the m suffix to specify that the number is a decimal.
        new Product("Laptop", 2500),
        new Product("Keyboard", 120),
        new Product("Mouse", 90),
        new Product("Display", 1000),
        new Product("Debugging Duck", 66)

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