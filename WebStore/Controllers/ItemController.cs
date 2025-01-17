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
        [Authorize]
        public void UpdateItem(string id, [FromBody] ItemCreateDto dto)
        {
            logic.UpdateItem(id, dto);
        }

        [HttpGet("{id}")]
        public ItemViewDto GetItem(string id)
        {
            return logic.GetItem(id);
        }
    }
}
