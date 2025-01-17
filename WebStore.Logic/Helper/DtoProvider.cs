using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Entities.Dtos.Item;
using WebStore.Entities.Dtos.Rating;
using WebStore.Entities.Dtos.Store;
using WebStore.Entities.Dtos.User;
using WebStore.Entities.Entity_Models;

namespace WebStore.Logic.Helper
{
    public class DtoProvider
    {
        UserManager<AppUser> userManager;
        public Mapper Mapper { get; }

        public DtoProvider(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemShortViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.AverageRating = src.Ratings?.Count > 0 ? src.Ratings.Average(r => r.Rate) : 0;
                    dest.StoreName = src.Store.Name;
                });
                cfg.CreateMap<AppUser, UserViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.IsAdmin = userManager.IsInRoleAsync(src, "Admin").Result;
                });
                cfg.CreateMap<Item, ItemViewDto>();
                cfg.CreateMap<ItemCreateDto, Item>();
                cfg.CreateMap<RatingCreateDto, Rating>();
                cfg.CreateMap<Rating, RatingViewDto>()
                .AfterMap((src, dest) =>
                {
                    var user = userManager.Users.First(u => u.Id == src.UserId);
                    dest.UserFullName = user.LastName! + " " + user.FirstName;
                });
                cfg.CreateMap<StoreCreateDto, Store>();
                cfg.CreateMap<Store, StoreViewDto>();
                cfg.CreateMap<Store, StoreShortViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.TotalItemsCount = src.Items?.Count() > 0 ? src.Items.Count() : 0;
                    dest.AvargePrice = src.Items?.Count() > 0 ? src.Items.Average(r => r.Price) : 0;
                    dest.Reliability = src.Items?.Where(x => x.Ratings?.Count() > 0).Count() > 0 ? src.Items.Select(x => x.Ratings).Count()
                    - src.Items.Where(x => x.Ratings.Average(r => r.Rate) >= 3).Count() <= src.Items.Select(x => x.Ratings).Count() / 2 : true;
                });

            });

            Mapper = new Mapper(config);
        }
    }
}
