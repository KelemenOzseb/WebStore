using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Entities.Dtos.Item;
using WebStore.Entities.Dtos.Rating;
using WebStore.Entities.Entity_Models;

namespace WebStore.Logic.Helper
{
    public class DtoProvider
    {
        public Mapper Mapper { get; }

        public DtoProvider()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemShortViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.AverageRating = src.Ratings?.Count > 0 ? src.Ratings.Average(r => r.Rate) : 0;
                    dest.StoreName = src.Store.Name;
                });
                cfg.CreateMap<Item, ItemViewDto>();
                cfg.CreateMap<ItemCreateDto, Item>();
                cfg.CreateMap<RatingCreateDto, Rating>();
                cfg.CreateMap<Rating, RatingViewDto>();
            });

            Mapper = new Mapper(config);
        }
    }
}
