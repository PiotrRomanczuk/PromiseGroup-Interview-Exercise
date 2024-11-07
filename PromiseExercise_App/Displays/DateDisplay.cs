public static class DateDisplay
{
    public static void Show()
    {
        DateTime date = DateTime.Now;
        Console.WriteLine($"\nToday is {date:d} at {date:hh:mm tt}.");
    }
}
