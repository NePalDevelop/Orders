using System;
using System.ComponentModel.DataAnnotations;

namespace Orders.Model
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [Range(0, 999)]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        [Required]
        [Range(1, 999)]
        public int Quantity { get; set; }
    }
}
