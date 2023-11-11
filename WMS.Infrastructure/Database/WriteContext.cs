using Microsoft.EntityFrameworkCore;
using WMS.Domain.Entities;

namespace WMS.Infrastructure.Database;

public class WriteContext : DbContext
{
    public WriteContext(DbContextOptions<WriteContext> options)
        : base(options)
    {
    }

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
            .HasOne(i => i.Warehouse);

        modelBuilder
            .Entity<OrderDetails>()
            .HasOne(i => i.Order);

        modelBuilder
            .Entity<OrderDetails>()
            .HasOne(i => i.Product);
    }
}