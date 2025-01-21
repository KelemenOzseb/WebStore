using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Entities.Dtos.ShoppingCart
{
    public class ShoppingCartViewDto
    {
        public IEnumerable<ShoppingCartItemViewDto>? Items { get; set; }
        public int TotalItemsCount => Items?.Sum(x => x.Quantity) ?? 0;
        public double SumPrice => Items?.Sum(x => x.Price * x.Quantity) ?? 0;
    }
}
