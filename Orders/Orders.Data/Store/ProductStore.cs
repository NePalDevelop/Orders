using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Orders.Data.Model;
namespace Orders.Data.Store
{
    public class ProductStore
    {
        private readonly OrdersContext _context;

        public ProductStore(OrdersContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
