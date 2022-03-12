using System;
using System.Collections.Generic;

namespace Orders.Model
{
    public class Order
    {
        public int Id { get; set; }

        public string Client { get; set; }

        public DateTime DateCreating { get; set; }

        public List<Item> Items { get; set; }
    }
}
