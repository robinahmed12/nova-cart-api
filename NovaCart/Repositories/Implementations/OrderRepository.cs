using Microsoft.EntityFrameworkCore;
using NovaCart.Data;
using NovaCart.Model;

namespace NovaCart.Repositories.Implementations
{
    public class OrderRepository(NovaCartDBContext context) : IOrderRepository
    {
        private readonly NovaCartDBContext _context = context;

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .AsNoTracking().ToListAsync();
        }
        public async Task<Order?> GetByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }
        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }
        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }
        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Orders.AnyAsync(c => c.OrderId == id);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
