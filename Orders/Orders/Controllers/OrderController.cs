using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orders.Helpers;
using Orders.Model;
using Orders.Data.Store;

namespace Orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderStore _orderStore;

        public OrderController(OrderStore orderStore)
        {
            _orderStore = orderStore;
        }

        // GET:<OrderController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            var orders = await _orderStore.GetOrders();

            return orders.Select(Mapper.MapOrderFromData).ToList();
        }

        // GET:<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            return Mapper.MapOrderFromData(await _orderStore.GetOrder(id));
        }

        // POST <OrderController>
        [HttpPost("{id}")]
        public async Task<ActionResult<Order>> Post([FromBody] Item item, int id)
        {
            if (!ModelState.IsValid || id < 0)
            {
                return ValidationProblem();
            }

            var order = await _orderStore.AddProduct(item.ProductId, item.Quantity, id);

            return Mapper.MapOrderFromData(order);
        }

        // Delete <OrderController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteItem([FromBody] int[] productIds, int id)
        {
            if (!ModelState.IsValid || id < 0)
            {
                return ValidationProblem();
            }

            var order = await _orderStore.DeleteProducts(productIds, id);

            return Mapper.MapOrderFromData(order);
        }
    }
}
