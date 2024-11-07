class Program
{
    static void Main(string[] args)
    {
        AppInitializer.Initialize();

        while (true)
        {
            // Console.Clear();
            WelcomeDisplay.Show();
            DateDisplay.Show();
            OrderSummaryDisplay.Show(AppInitializer.CurrentOrder, AppInitializer.OrderProcessor);
            Menu.Display();

            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                MenuInputHandler.ProcessUserInput(userInput, AppInitializer.OrderProcessor);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Thread.Sleep(2000); // Wait for 2 seconds to allow the user to read the error message
            }
        }
    }
}