using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Entities.Dtos.Item
{
    public class ItemCreateDto
    {
        public string StoreId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
