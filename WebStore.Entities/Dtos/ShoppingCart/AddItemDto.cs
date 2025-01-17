using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Entities.Dtos.ShoppingCart
{
    public class AddItemDto
    {
        public string ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
