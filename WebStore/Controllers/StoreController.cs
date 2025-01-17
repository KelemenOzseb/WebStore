using Microsoft.AspNetCore.Mvc;
using WebStore.Entities.Dtos.Store;
using WebStore.Logic.Logic;

namespace WebStore.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        StoreLogic logic;
        public StoreController(StoreLogic logic)
        {
            this.logic = logic;
        }
        [HttpPost]
        public void AddStore(StoreCreateDto dto)
        {
            logic.AddStore(dto);
        }

        [HttpGet]
        public IEnumerable<StoreShortViewDto> GetAllStore()
        {
            return logic.GetAllStores();
        }
        [HttpPut("{id}")]
        public void UpdateStore(string id, [FromBody] StoreCreateDto dto)
        {
            logic.UpdateStore(id, dto);
        }

        [HttpGet("{id}")]
        public StoreViewDto GetStore(string id)
        {
            return logic.GetStore(id);
        }
    }
}
