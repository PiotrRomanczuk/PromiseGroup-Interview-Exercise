using System;

public static class UserInput
{
    public static void GetUserInput(int number, OrderProcessor orderProcessor)
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
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("You entered an invalid number.");
                break;
        }
    }
}
