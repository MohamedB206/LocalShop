using LocalShopDataAccessLayer.Models;

namespace LocalShopBusinessLayer.Services
{
    public class OrderServices
    {
        private LocalShopDbContext _context;
        public OrderServices()
        {
            _context = new LocalShopDbContext();
        }

        public async Task<Order> PostOrder(Order order)
        {
            await _context.AddAsync(order);
            if (await _context.SaveChangesAsync() < 1)
            {
                return null;
            }
            return order;
        }
    }
}
