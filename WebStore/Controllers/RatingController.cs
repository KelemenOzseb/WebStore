using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Entities.Dtos.Rating;
using WebStore.Logic.Logic;

namespace WebStore.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RatingController : ControllerBase
    {
        RatingLogic logic { get; set; }
        public RatingController(RatingLogic logic)
        {
            this.logic = logic;
        }
        [HttpPost]
        public void AddRating(RatingCreateDto dto)
        {
            logic.AddRating(dto);
        }
    }
}
