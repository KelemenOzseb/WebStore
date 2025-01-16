using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IIdentity = WebStore.Entities.Helper.IIdentity;


namespace WebStore.Entities.Entity_Models
{
    public class Rating : IIdentity
    {
        public Rating(string itemId, string text, int rate)
        {
            Id = Guid.NewGuid().ToString();
            ItemId = itemId;
            Text = text;
            Rate = rate;
        }

        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [StringLength(50)]
        public string ItemId { get; set; }

        [NotMapped]
        public virtual Item? Item { get; set; }

        [StringLength(200)]
        public string Text { get; set; }

        [Range(1, 5)]
        public int Rate { get; set; }
    }
}
