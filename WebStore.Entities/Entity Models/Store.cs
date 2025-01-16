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
    public class Store : IIdentity
    {
        public Store(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Reliability = true;
        }
        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public bool Reliability { get; set; }

        [NotMapped]
        public virtual ICollection<Item>? Items { get; set; }
    }
}
