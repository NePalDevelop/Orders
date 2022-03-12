using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Orders.Data.Model;

namespace Orders.Data.Store
{
    public class OrderStore
    {
        private readonly OrdersContext _context;

        public OrderStore(OrdersContext context)
        {
            _context = context;
        }
        
        public async Task<List<Order>> GetOrders()
        {
            IQueryable<Order> query;

            query = _context.Orders.Include(o => o.Items)
                .ThenInclude(i => i.Product);

            var orders = await query.ToListAsync();

            return orders;
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _context.Orders.Include(o => o.Items)
                .ThenInclude(i => i.Product).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order>  AddProduct(int productId, int quantity, int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null) return null;

            var order = await _context.Orders.Include(o => o.Items)
                .ThenInclude(i => i.Product).FirstOrDefaultAsync(o => o.Id == id);
            
            if (order == null) return null;

            var isExistItem = false;

            foreach (var i in order.Items) { 
                if (i.ProductId == productId)
                {
                    i.Quantity += quantity;
                    isExistItem = true;
                    break;
                }
            };

            if (!isExistItem)
            {
                Item item = new()
                {
                    ProductId = productId,
                    OrderId = id,
                    Quantity = quantity

                };
                order.Items.Add(item);
            }

            _context.Update(order);

            await _context.SaveChangesAsync();

            return await GetOrder(id);
        }

        public async Task<Order> DeleteProduct(int productId, int orderId)
        {
            var order = await _context.Orders.Include(o => o.Items)
                .ThenInclude(i => i.Product).FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null) return null;

            var isExistItem = false;
            
            foreach (var i in order.Items)
            {
                if (i.ProductId == productId)
                {
                    order.Items.Remove(i);
                    isExistItem = true;
                    break;
                }
            };

            if (!isExistItem)
            {
                _context.Update(order);

                await _context.SaveChangesAsync();
            }

            return await GetOrder(orderId);
        }
    }
}

