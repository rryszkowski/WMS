using Microsoft.EntityFrameworkCore;
using WMS.Domain.Entities;

namespace WMS.Infrastructure.Database.Write;

public class WriteContext : DbContext
{
    public WriteContext(DbContextOptions<WriteContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Inventory> Inventories { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderDetails> OrderDetails { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Shipment> Shipments { get; set; } = null!;
    public DbSet<Warehouse> Warehouses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Inventory>()
            .HasOne(i => i.Product);

        modelBuilder
            .Entity<Inventory>()
            .HasOne(i => i.Warehouse);

        modelBuilder
            .Entity<Shipment>()
            .HasOne(i => i.Order);

        modelBuilder
            .Entity<Shipment>()
            .Property(s => s.Status)
            .HasConversion<string>();

        modelBuilder
            .Entity<Shipment>()
            .HasOne(i => i.Warehouse);

        modelBuilder
            .Entity<Order>()
            .HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId);

        modelBuilder
            .Entity<Order>()
            .Property(o => o.Status)
            .HasConversion<string>();

        modelBuilder
            .Entity<OrderDetails>()
            .HasOne(i => i.Product);
    }
}