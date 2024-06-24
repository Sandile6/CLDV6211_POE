using KhumaloTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KhumaloTest.Data
{
    public class KhumaloTestContext : DbContext
    {
        public KhumaloTestContext(DbContextOptions<KhumaloTestContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Craftwork> Craftworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Craftwork)
            .WithMany() // Assuming Craftwork does not reference OrderItem
            .HasForeignKey(oi => oi.CraftworkId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);
        }
    }
}