using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Data;
using WebStore.Endpoint.Helpers;
using WebStore.Logic.Helper;
using WebStore.Logic.Logic;

namespace WebStore.Endpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient(typeof(Repository<>));
            builder.Services.AddTransient<RatingLogic>();
            builder.Services.AddTransient<ItemLogic>();
            builder.Services.AddTransient<StoreLogic>();
            builder.Services.AddTransient<DtoProvider>();
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(
                  option =>
                  {
                      option.Password.RequireDigit = false;
                      option.Password.RequiredLength = 6;
                      option.Password.RequireNonAlphanumeric = false;
                      option.Password.RequireUppercase = false;
                      option.Password.RequireLowercase = false;
                  }
            )
              .AddDefaultTokenProviders();

            // Add services to the container.
            builder.Services.AddDbContext<ShopContext>(options =>
            {
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StoreDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;MultipleActiveResultSets=True");
                options.UseLazyLoadingProxies();
            });

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            builder.Services.AddControllers(opt =>
            {
                opt.Filters.Add<ExceptionFilter>();
                opt.Filters.Add<ValidationFilterAttribute>();
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
