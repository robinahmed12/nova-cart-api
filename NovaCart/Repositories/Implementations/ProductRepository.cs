using Microsoft.EntityFrameworkCore;
using NovaCart.Data;
using NovaCart.Model;

namespace NovaCart.Repositories.Implementations
{
    
        public class ProductRepository(NovaCartDBContext context) : IProductRepository
        {
            private readonly NovaCartDBContext _context = context;

        public async Task<IEnumerable<Product>> GetAllAsync()
            {
                return await _context.Products.Include(p => p.Category).AsNoTracking().ToListAsync();
            }
            public async Task<Product?> GetByIdAsync(int productId)
            {
                return await _context.Products.Include(p => p.Category)
                    .AsNoTracking().FirstOrDefaultAsync(p => p.ProductId == productId);
            }
            public async Task AddAsync(Product product)
            {
                await _context.Products.AddAsync(product);
            }
            public void Update(Product product)
            {
                _context.Products.Update(product);
            }
            public void Delete(Product product)
            {
                _context.Products.Remove(product);
            }
            public async Task<bool> ExistsAsync(int id)
            {
                return await _context.Products.AnyAsync(c => c.ProductId == id);
            }
            public async Task SaveAsync()
            {
                await _context.SaveChangesAsync();
            }
        }
    }

