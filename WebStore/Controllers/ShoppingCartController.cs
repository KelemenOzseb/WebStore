using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data.ShoppingCart;
using WebStore.Data;
using WebStore.Logic.Logic;
using WebStore.Entities.Dtos.ShoppingCart;

namespace WebStore.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShoppingCartController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ShoppingCartLogic logic;

        public ShoppingCartController(UserManager<AppUser> userManager, ShoppingCartLogic logic)
        {
            this.userManager = userManager;
            this.logic = logic;
        }

        [HttpGet]
        public async Task<ShoppingCartViewDto> GetCart()
        {
            var user = await userManager.GetUserAsync(User);
            return logic.GetCart(user.Id);
        }

        [HttpPost("add")]
        public async Task AddItemToCart(AddItemDto dto)
        {
            var user = await userManager.GetUserAsync(User);
            logic.AddItemToCart(user.Id, dto.ItemId, dto.Quantity);
        }

        [HttpDelete("remove")]
        public async Task RemoveItemFromCart([FromQuery] string itemId)
        {
            var user = await userManager.GetUserAsync(User);
            logic.RemoveItemFromCart(user.Id, itemId);
        }
    }
}
