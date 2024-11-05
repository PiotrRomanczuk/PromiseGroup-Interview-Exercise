public class UserManager
{
    private readonly DatabaseHelper dbHelper;
    private readonly string userId;

    public UserManager(DatabaseHelper dbHelper, string userId)
    {
        this.dbHelper = dbHelper;
        this.userId = userId;
    }

    public void CreateOrUpdateUser()
    {
        dbHelper.CreateUser(userId, "John Doe");
    }

    public void DisplayGreeting()
    {
        string name = dbHelper.GetUserNameById(userId);
        Console.WriteLine(name != null ? $"Hello, {name}!" : "User not found.");
    }
}
