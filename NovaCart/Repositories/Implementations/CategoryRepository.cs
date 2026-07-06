using Microsoft.EntityFrameworkCore;
using NovaCart.Data;
using NovaCart.Model;

namespace NovaCart.Repositories.Implementations
{
    public class CategoryRepository(NovaCartDBContext context) : ICategoryRepository

    {
        private readonly NovaCartDBContext _context = context;

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }
        public async Task<Category?> GetByIdAsync(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }
        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Categories.AnyAsync(c => c.CategoryId == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
