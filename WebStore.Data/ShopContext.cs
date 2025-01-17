using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WebStore.Entities.Entity_Models;

namespace WebStore.Data
{
    public class ShopContext : IdentityDbContext
    {
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }
        public ShopContext(DbContextOptions<ShopContext> ctx) : base(ctx) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasMany(i => i.Ratings)
                .WithOne(r => r.Item)
                .HasForeignKey(r => r.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Store>()
                .HasMany(s => s.Items)
                .WithOne(i => i.Store)
                .HasForeignKey(i => i.StoreId)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
