using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Entities.Dtos.Rating;
using WebStore.Entities.Entity_Models;

namespace WebStore.Entities.Dtos.Item
{
    public class ItemViewDto
    {
        public string StoreId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public IEnumerable<RatingViewDto>? Ratings { get; set; }
        public int RatingCount => Ratings?.Count() ?? 0;

        public double AverageRating => Ratings?.Count() > 0 ? Ratings.Average(r => r.Rate) : 0;
    }
}
