public class UserModel
{
    public required string UserId { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public ICollection<OrderModel>? Orders { get; set; }
}
