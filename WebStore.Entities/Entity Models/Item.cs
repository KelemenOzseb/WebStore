using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using IIdentity = WebStore.Entities.Helper.IIdentity;

namespace WebStore.Entities.Entity_Models
{
    public class Item : IIdentity
    {
        public Item(string storeId, string name, double price, string description, string type)
        {
            Id = Guid.NewGuid().ToString();
            StoreId = storeId;
            Name = name;
            Price = price;
            Description = description;
            Type = type;
        }

        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [StringLength(50)]
        public string StoreId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        [Range(0, 99999999)]
        public double Price { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [NotMapped]
        public virtual Store? Store { get; set; }
        
        [NotMapped]
        public virtual ICollection<Rating>? Ratings { get; set; }
    }
}
