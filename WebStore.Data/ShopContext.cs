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
using WebStore.Entities.Entity_Models.ShoppingCart;

namespace WebStore.Data
{
    public class ShopContext : IdentityDbContext
    {
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

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
            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(sci => sci.ShoppingCart)
                .WithMany(sc => sc.ShoppingCartItems)
                .HasForeignKey(sci => sci.ShoppingCartId);

            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(sci => sci.Item)
                .WithMany()
                .HasForeignKey(sci => sci.ItemId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
