using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Entities.Dtos.Item;
using WebStore.Logic.Logic;

namespace WebStore.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        ItemLogic logic;
        public ItemController(ItemLogic logic)
        {
            this.logic = logic;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void AddItems(ItemCreateDto dto)
        {
            logic.AddItem(dto);
        }

        [HttpGet]
        public IEnumerable<ItemShortViewDto> GetAllItems()
        {
            return logic.GetAllItems();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void UpdateItem(string id, [FromBody] ItemCreateDto dto)
        {
            logic.UpdateItem(id, dto);
        }

        [HttpGet("{id}")]
        public ItemViewDto GetItem(string id)
        {
            return logic.GetItem(id);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void DeleteMovie(string id)
        {
            logic.DeleteItem(id);
        }
    }
}
