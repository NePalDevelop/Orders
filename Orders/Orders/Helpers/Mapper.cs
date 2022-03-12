using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orders.Model;

namespace Orders.Helpers
{
    public static class Mapper
    {
        public static Order MapOrderFromData(Data.Model.Order order)
        {
            if (order == null) return null;

            Order modelOrder = new()
            {
                Id = order.Id,
                Client = order.Client,
                DateCreating = order.DateCreating,
                Items = order.Items.Select(i => new Item
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity
                }).ToList()
            };
            return modelOrder;
        }
    }
}

