using DuongTrongTuanAnh_2280600041_lab06.Data;
using DuongTrongTuanAnh_2280600041_lab06.Models;
using Microsoft.EntityFrameworkCore;

namespace DuongTrongTuanAnh_2280600041_lab06.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                return _context.Products.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all products: {ex.Message}");
                throw;
            }
        }

        public Product GetById(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    throw new KeyNotFoundException($"Product with ID {id} not found");
                }
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting product by ID {id}: {ex.Message}");
                throw;
            }
        }

        public Product Add(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
                throw;
            }
        }

        public void Update(Product product)
        {
            try
            {
                var existingProduct = _context.Products.Find(product.Id);
                if (existingProduct == null)
                {
                    throw new KeyNotFoundException($"Product with ID {product.Id} not found");
                }

                // Update the existing product's properties
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                existingProduct.Description = product.Description;

                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"Concurrency error updating product {product.Id}: {ex.Message}");
                throw;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database error updating product {product.Id}: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product {product.Id}: {ex.Message}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                }
                else
                {
                    throw new KeyNotFoundException($"Product with ID {id} not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product {id}: {ex.Message}");
                throw;
            }
        }
    }
}
