using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Entities.Dtos.Item;
using WebStore.Entities.Entity_Models;
using WebStore.Logic.Helper;

namespace WebStore.Logic.Logic
{
    public class ItemLogic
    {
        Repository<Item> repo;
        DtoProvider dtoProvider;

        public ItemLogic(Repository<Item> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }

        public void AddItem(ItemCreateDto itemCreateDto)
        {
            Item i = dtoProvider.Mapper.Map<Item>(itemCreateDto);
            if (repo.GetAll().FirstOrDefault(x => (x.Name == i.Name) && (x.Store == i.Store)) == null)
            {
                repo.Create(i);
            }
            else
            {
                throw new ArgumentException("Ez a termék már hozzá lett adva ettől az áruháztól!");
            }
        }
        public IEnumerable<ItemShortViewDto> GetAllItems()
        {
            return repo.GetAll().Select(x =>
                dtoProvider.Mapper.Map<ItemShortViewDto>(x)
            );
        }
        public void UpdateItem(string id, ItemCreateDto dto)
        {
            var old = repo.FindById(id);
            dtoProvider.Mapper.Map(dto, old);
            repo.Update(old);
        }
        public void DeleteItem(string id)
        {
            repo.DeleteById(id);
        }
        public ItemViewDto GetItem(string id)
        {
            var model = repo.FindById(id);
            return dtoProvider.Mapper.Map<ItemViewDto>(model);
        }
    }
}
