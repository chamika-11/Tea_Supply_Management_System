using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Tea_Management.Models;

namespace TeaManagement.Data
{
    public class TeaDbContext : DbContext
    {
        public TeaDbContext(DbContextOptions<TeaDbContext> options) : base(options)
        {
        }

        public DbSet<Factory> Factories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TeaCollection> TeaCollections { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factory>()
                .HasMany(f => f.Suppliers)
                .WithOne(s => s.Factory)
                .HasForeignKey(s => s.FactoryId);

            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Collections)
                .WithOne(c => c.Supplier)
                .HasForeignKey(c => c.SupplierId);

            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Payments)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId);
        }
    }
}
