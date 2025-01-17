using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Entities.Dtos.Store;
using WebStore.Entities.Entity_Models;
using WebStore.Logic.Helper;

namespace WebStore.Logic.Logic
{
    public class StoreLogic
    {
        Repository<Store> repo;
        DtoProvider dtoProvider;

        public StoreLogic(Repository<Store> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }
        public void AddStore(StoreCreateDto storeCreateDto)
        {
            Store s = dtoProvider.Mapper.Map<Store>(storeCreateDto);
            if (repo.GetAll().FirstOrDefault(x => x.Name == s.Name) == null)
            {
                repo.Create(s);
            }
            else
            {
                throw new ArgumentException("Ez az áruház már hozzá lett adva!");
            }
        }
        public IEnumerable<StoreShortViewDto> GetAllStores()
        {
            return repo.GetAll().Select(x =>
                dtoProvider.Mapper.Map<StoreShortViewDto>(x)
            );
        }
        public void UpdateStore(string id, StoreCreateDto dto)
        {
            var old = repo.FindById(id);
            dtoProvider.Mapper.Map(dto, old);
            repo.Update(old);
        }
        public void DeleteStore(string id)
        {
            repo.DeleteById(id);
        }
        public StoreViewDto GetStore(string id)
        {
            var model = repo.FindById(id);
            return dtoProvider.Mapper.Map<StoreViewDto>(model);
        }
    }
}
