using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<OrderModel> Orders { get; set; }
    public DbSet<ProductModel> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderModel>()
            .HasKey(o => o.OrderModelId); // Configure primary key

        modelBuilder.Entity<UserModel>()
            .HasKey(u => u.UserId); // Configure primary key for UserModel

        modelBuilder.Entity<ProductModel>()
            .HasKey(p => p.ProductModelId); // Configure primary key for ProductModel

        // Configure other relationships and settings
    }
}