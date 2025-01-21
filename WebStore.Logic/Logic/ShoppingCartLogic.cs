using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Entities.Dtos.ShoppingCart;
using WebStore.Entities.Entity_Models.ShoppingCart;

namespace WebStore.Logic.Logic
{
    public class ShoppingCartLogic
    {
        Repository<ShoppingCart> shoppingCartRepo;
        Repository<ShoppingCartItem> shoppingCartItemRepo;

        public ShoppingCartLogic(Repository<ShoppingCart> shoppingCartRepo, Repository<ShoppingCartItem> shoppingCartItemRepo)
        {
            this.shoppingCartRepo = shoppingCartRepo;
            this.shoppingCartItemRepo = shoppingCartItemRepo;
        }

        public ShoppingCartViewDto GetCart(string userId)
        {
            var cart = shoppingCartRepo.GetAll()
                .FirstOrDefault(c => c.UserId == userId);

            if (cart == null || cart.ShoppingCartItems == null)
            {
                return new ShoppingCartViewDto
                {
                    Items = new List<ShoppingCartItemViewDto>()
                };
            }

            var items = cart.ShoppingCartItems.Select(i => new ShoppingCartItemViewDto
            {
                ItemId = i.ItemId,
                Name = i.Item?.Name ?? "Unknown Item", // Feltételezve, hogy az Item entitásnak van Name tulajdonsága
                Price = i.Item?.Price ?? 0,           // Feltételezve, hogy az Item entitásnak van Price tulajdonsága
                Quantity = i.Quantity
            });

            return new ShoppingCartViewDto
            {
                Items = items
            };
        }

        public void AddItemToCart(string userId, string itemId, int quantity)
        {
            var cart = shoppingCartRepo.GetAll()
                .FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = userId,
                    ShoppingCartItems = new List<ShoppingCartItem>()
                };
                shoppingCartRepo.Create(cart);
            }

            var existingItem = cart.ShoppingCartItems?
                .FirstOrDefault(i => i.ItemId == itemId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                shoppingCartItemRepo.Update(existingItem);
            }
            else
            {
                var newItem = new ShoppingCartItem(itemId, quantity)
                {
                    ShoppingCartId = cart.Id
                };
                shoppingCartItemRepo.Create(newItem);
            }
        }

        public void RemoveItemFromCart(string userId, string itemId)
        {
            var cart = shoppingCartRepo.GetAll()
                .FirstOrDefault(c => c.UserId == userId);

            if (cart == null) return;

            var item = cart.ShoppingCartItems?.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null)
            {
                shoppingCartItemRepo.Delete(item);
            }
        }
    }
}
