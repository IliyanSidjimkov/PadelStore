using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadelStore.ViewModels
{
    public class CartItemViewModel
    {
        public Guid  Id { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
}
