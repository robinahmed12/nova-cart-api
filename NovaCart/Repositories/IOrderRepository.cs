using NovaCart.Model;

namespace NovaCart.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task AddAsync(Order order);
        void Update(Order order);
        void Delete(Order order);
        Task<bool> ExistsAsync(int id);
        Task SaveAsync();
    }
}
