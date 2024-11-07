public class OrderModel
{
    public int OrderModelId { get; set; } // Primary key
    public DateTime OrderDate { get; set; }
    public int UserId { get; set; }
    public List<ProductModel> OrderProducts { get; set; } = new List<ProductModel>();
}