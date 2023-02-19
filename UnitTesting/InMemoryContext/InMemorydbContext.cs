using ECommerce_Additional.DbContexts;
using ECommerce_Additional.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace ECommerce_Additional.InMemoryContext
{
    public static class InMemorydbContext
    {
        /// <summary>
        /// This method is used to create the InMemeorydatabase
        /// </summary>
        public static UserCartContext userCartContext()
        {

            var options = new DbContextOptionsBuilder<UserCartContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var context = new UserCartContext(options);
            context.WishLists.Add(new WishList() {
                Id = new Guid("698f8b7b-65d2-4425-b724-46c076943f17"),
                UserId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                ProductId = new Guid("2b6aa7d6-1974-430f-a760-3ced549d0471"),
                Name = "mobiles"
            });
            context.Orders.Add(new Order() {
                Id = new Guid("917c0fc2-7994-4fa4-a96b-d9a12a3fc907"),
                UserId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                ProductId = new Guid("2b6aa7d6-1974-430f-a760-3ced549d0471"),
                Quantity = 1,
                Price = 5000,
                PaymentMethod = "UPI",
                PaymentTime = DateTime.Now,
                IsOrder = false
            });
            context.SaveChanges();
            return context;
        }
    }
}
