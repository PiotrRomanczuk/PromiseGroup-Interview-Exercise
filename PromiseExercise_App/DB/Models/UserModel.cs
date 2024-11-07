using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class UserModel
{
    [Key]
    public int UserId { get; set; } // Primary key

    [Required]
    public string? Name { get; set; } // Nullable property

    public string? Email { get; set; }

    public List<OrderModel> Orders { get; set; } = new List<OrderModel>();
}