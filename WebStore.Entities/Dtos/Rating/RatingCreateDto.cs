using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Entities.Dtos.Rating
{
    public class RatingCreateDto
    {
        public string ItemId { get; set; }

        [MinLength(10)]
        [MaxLength(500)]
        public string Text { get; set; }

        [Range(1, 5)]
        public int Rate { get; set; }

    }
}
