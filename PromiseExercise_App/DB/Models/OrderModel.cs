using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderModel
{
    [Key]
    public int OrderModelId { get; set; } // Primary key

    [Required]
    public int UserId { get; set; } // Foreign key to UserModel

    [ForeignKey("UserId")]
    public UserModel User { get; set; } // Navigation property

    [Required]
    public List<ProductModel> OrderProducts { get; set; } = new List<ProductModel>();

    [Required]
    public DateTime OrderDate { get; set; }
}