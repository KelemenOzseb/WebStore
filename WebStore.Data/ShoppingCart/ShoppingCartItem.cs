using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WebStore.Entities.Entity_Models;
using IIdentity = WebStore.Entities.Helper.IIdentity;

namespace WebStore.Data.ShoppingCart
{
    public class ShoppingCartItem : IIdentity
    {
        public ShoppingCartItem(string itemId, int quantity)
        {
            Id = Guid.NewGuid().ToString();
            ItemId = itemId;
            Quantity = quantity;
        }
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(50)]
        public string ShoppingCartId { get; set; }
        [NotMapped]
        public virtual ShoppingCart ShoppingCart { get; set; }
        public string ItemId { get; set; }
        [NotMapped]
        public virtual Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
