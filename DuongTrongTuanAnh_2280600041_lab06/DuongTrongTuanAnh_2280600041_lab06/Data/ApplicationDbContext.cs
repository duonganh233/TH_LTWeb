using DuongTrongTuanAnh_2280600041_lab06.Models;
using Microsoft.EntityFrameworkCore;

namespace DuongTrongTuanAnh_2280600041_lab06.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            try
            {
                // Attempt to ensure database exists on construction
                Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ensuring database exists: {ex.Message}");
                throw;
            }
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            try
            {
                // Configure Product entity
                modelBuilder.Entity<Product>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                    entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                    entity.Property(e => e.Description).HasMaxLength(500);
                });

                // Seed data
                modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "Sample Product 1",
                        Price = 99.99m,
                        Quantity = 10,
                        Description = "This is a sample product"
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Sample Product 2",
                        Price = 149.99m,
                        Quantity = 5,
                        Description = "Another sample product"
                    }
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OnModelCreating: {ex.Message}");
                throw;
            }
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error saving changes to database: {ex.Message}");
                throw;
            }
        }
    }
} 