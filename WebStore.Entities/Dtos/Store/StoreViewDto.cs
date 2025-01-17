using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Entities.Dtos.Item;

namespace WebStore.Entities.Dtos.Store
{
    public class StoreViewDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ItemShortViewDto>? Items { get; set; }
        public bool Reliability => Items?.Count() > 0 ? Items.Count() - Items.Count(x => x.AverageRating >= 3) > Items.Count() / 1.333 : true;
    }
}
