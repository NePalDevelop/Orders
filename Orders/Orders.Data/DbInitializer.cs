using System;
using System.Linq;
using Orders.Data.Model;

namespace Orders.Data
{
    public class DbInitializer
    {
        public static void Initialize(OrdersContext context)
        {
            context.Database.EnsureCreated();
            if (context.Orders.Any())
            {
                return;
            }

            var products = new Product[]
            {
                new Product{Name = "Куртка"},
                new Product{Name = "Майка"},
                new Product{Name = "Брюки"},
                new Product{Name = "Рубашка"},
                new Product{Name = "Шорты"}
            };

            context.Products.AddRange(products);
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order{Client = "Иванов", DateCreating = DateTime.Parse("2022-09-03")},
                new Order{Client = "Петров", DateCreating = DateTime.Parse("2022-09-04")},
                new Order{Client = "Сидоров", DateCreating = DateTime.Parse("2022-09-05")}
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();

            var items = new Item[]
            {
                new Item {ProductId = 1, OrderId = 1, Quantity = 5},
                new Item {ProductId = 2, OrderId = 1, Quantity = 4},
                new Item {ProductId = 3, OrderId = 2, Quantity = 3},
                new Item {ProductId = 4, OrderId = 2, Quantity = 2},
                new Item {ProductId = 5, OrderId = 3, Quantity = 1},
                new Item {ProductId = 1, OrderId = 3, Quantity = 5}
            };

            context.Items.AddRange(items);
            context.SaveChanges();

            //var orders = new Order[]
            //{
            //    new Order{Client = "Иванов", DateCreating = DateTime.Parse("2022-09-03")},
            //    new Order{Client = "Петров", DateCreating = DateTime.Parse("2022-09-04")},
            //    new Order{Client = "Сидоров", DateCreating = DateTime.Parse("2022-09-05")}
            //};

            //context.Orders.AddRange(orders);
            //context.SaveChanges();
        }
    }
}
