using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Data.ShoppingCart
{
    public class ShoppingCartItemViewDto
    {
        public string ItemId { get; set; }
        public string Name { get; set; } = "";
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
