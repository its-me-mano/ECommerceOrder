using ECommerce_Additional.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerce_Additional.DbContexts
{
    public class UserCartContext : DbContext
    {
        public UserCartContext(DbContextOptions<UserCartContext> options) : base(options)
        {

        }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<WishList>().HasData(new WishList()
            {
                Id = new Guid("698f8b7b-65d2-4425-b724-46c076943f17"),
                UserId=new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                ProductId=new Guid("2b6aa7d6-1974-430f-a760-3ced549d0471"),
                Name="mobiles"
            });
            modelBuilder.Entity<Order>().HasData(new Order()
            {
                Id = new Guid("917c0fc2-7994-4fa4-a96b-d9a12a3fc907"),
                UserId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                ProductId = new Guid("2b6aa7d6-1974-430f-a760-3ced549d0471"),
                Quantity = 1,
                Price = 5000,
                PaymentMethod = "UPI",
                PaymentTime = DateTime.Now,
                IsOrder = false

            }); ;

            
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
