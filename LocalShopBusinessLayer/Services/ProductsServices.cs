using LocalShopDataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
namespace LocalShop.Services
{
    public class ProductsServices
    {
        private LocalShopDbContext _context;
        public ProductsServices()
        {
            _context = new LocalShopDbContext();
        }

        public async Task<Product?> ProductView(int ProductID)
        {
            Product? P = await _context.Products.FirstOrDefaultAsync(P => P.ProductId == ProductID);
            return P;
        }
        public async Task<Product?> ProductView(string ProductName)
        {
            Product? P = await _context.Products.FirstOrDefaultAsync(P => P.Name == ProductName);
            return P;
        }

        public async Task<Product?> ProductSmallView(int ProductID)
        {
            Product? P = await _context.Products.FirstOrDefaultAsync(P => P.ProductId == ProductID);
            return P;
        }
        public async Task<Product?> ProductSmallView(string ProductName)
        {
            Product? P = await _context.Products.FirstOrDefaultAsync(P => P.Name == ProductName);
            return P;
        }
        public async Task<List<Product>> GetProductBySearch(string SearchInput)
        {
           List<Product> p = await _context.Products.Where(P=> EF.Functions.Like(P.Name , $"%{SearchInput.Trim()}%")).ToListAsync();
           return p;
        }
    }
}
