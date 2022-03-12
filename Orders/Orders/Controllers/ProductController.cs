using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.Data.Model;
using Orders.Data.Store;

namespace Orders.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductStore _productStore;

        public ProductController(ProductStore productStore)
        {
            _productStore = productStore;
        }

        // GET:<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _productStore.GetProducts();
        }
    }
}
