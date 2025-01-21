using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IIdentity = WebStore.Entities.Helper.IIdentity;

namespace WebStore.Entities.Entity_Models.ShoppingCart
{
    public class ShoppingCart : IIdentity
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string UserId { get; set; } = "";

        [NotMapped]
        public virtual ICollection<ShoppingCartItem>? ShoppingCartItems { get; set; }
    }
}
