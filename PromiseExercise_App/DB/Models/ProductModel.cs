using System.ComponentModel.DataAnnotations;

public class ProductModel
{
    [Key]
    public int ProductModelId { get; set; } // Primary key

    [Required]
    public required Product Product { get; set; }

    [Required]
    public int Quantity { get; set; }
}