using System;
using System.Collections.Generic;

class Program
{
    private static List<IProduct> CurrentOrder = new List<IProduct>();
    private static OrderProcessor orderProcessor;

    private static void Initialize()
    {
        orderProcessor = new OrderProcessor(CurrentOrder);
    }

    static void Main(string[] args)
    {
        Initialize();

        while (true)
        {
            Console.Clear();
            WelcomeDisplay.Show();
            DateDisplay.Show();
            OrderSummaryDisplay.Show(CurrentOrder, orderProcessor);
            Menu.Display();

            int userInput = int.Parse(Console.ReadLine());
            UserInputHandler.ProcessUserInput(userInput, orderProcessor);
        }
    }


}

