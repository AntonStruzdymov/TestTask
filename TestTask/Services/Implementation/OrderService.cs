using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<Order> GetOrder()
        {
            var order = _context.Orders.OrderByDescending(a=>a.Quantity*a.Price).FirstOrDefault();
            return Task.FromResult(order);
        }

        public Task<List<Order>> GetOrders()
        {
            var orders = _context.Orders.Where(a=>a.Quantity>10).ToList();
            return Task.FromResult(orders);
        }
    }
}
