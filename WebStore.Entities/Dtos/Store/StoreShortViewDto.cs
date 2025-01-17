using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Entities.Dtos.Store
{
    public class StoreShortViewDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double TotalItemsCount { get; set; } = 0;
        public double AvargePrice { get; set; } = 0;
        public bool Reliability { get; set; } = true;
    }
}
