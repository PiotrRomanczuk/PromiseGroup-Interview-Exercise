using System;

public static class MenuInputHandler
{
    public static void ProcessUserInput(int number, OrderProcessor orderProcessor)
    {
        try
        {
            switch (number)
            {
                case 1:
                    orderProcessor.AddProduct();
                    break;
                case 2:
                    orderProcessor.DeleteProduct();
                    break;
                case 3:
                    orderProcessor.CheckOrder();
                    break;
                case 4:
                    orderProcessor.SaveOrder();
                    break;
                case 5:
                    orderProcessor.CheckAllOrders();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("You entered an invalid number.");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }
}
