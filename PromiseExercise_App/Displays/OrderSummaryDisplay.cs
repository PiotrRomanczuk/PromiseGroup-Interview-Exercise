public static class OrderSummaryDisplay
{
    public static void Show(List<IProduct> currentOrder, OrderProcessor orderProcessor)
    {
        decimal totalOrderPrice = currentOrder.Sum(product => product.Price);
        decimal totalDiscount = orderProcessor.GetDiscount();
        decimal totalOrderPriceAfterDiscount = totalOrderPrice - totalDiscount;

        Console.WriteLine($"\nYour current order price equals: {totalOrderPrice:C}");
        Console.WriteLine($"Your current order discount: {totalDiscount:C}");
        Console.WriteLine($"Your current order price after discount: {totalOrderPriceAfterDiscount:C}");
    }
}
