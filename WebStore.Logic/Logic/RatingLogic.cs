using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Entities.Dtos.Rating;
using WebStore.Entities.Entity_Models;
using WebStore.Logic.Helper;

namespace WebStore.Logic.Logic
{
    public class RatingLogic
    {
        Repository<Rating> repo;
        DtoProvider dtoProvider;
        public RatingLogic(Repository<Rating> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }
        public void AddRating(RatingCreateDto dto, string userId)
        {
            var model = dtoProvider.Mapper.Map<Rating>(dto);
            model.UserId = userId;
            repo.Create(model);
        }
    }
}
