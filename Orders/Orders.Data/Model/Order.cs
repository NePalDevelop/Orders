using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Data.Model
{
    public class Order
    {
        public int Id { get; set; }

        public string Client { get; set; }

        public DateTime DateCreating { get; set; }

        public List<Item> Items { get; set; }
    }
}
