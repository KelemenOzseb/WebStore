using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Entities.Dtos.Rating;
using WebStore.Logic.Logic;

namespace WebStore.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RatingController : ControllerBase
    {
        UserManager<AppUser> userManager;
        RatingLogic logic { get; set; }
        public RatingController(UserManager<AppUser> userManager, RatingLogic logic)
        {
            this.userManager = userManager;
            this.logic = logic;
        }

        [HttpPost]
        public async Task AddRating(RatingCreateDto dto)
        {
            var user = await userManager.GetUserAsync(User);
            logic.AddRating(dto, user.Id);
        }
    }
}
