using ECommerce_Additional.Entities.Dto;
using ECommerce_Additional.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce_Additional.Contracts.IServices
{
    public interface IOrderServices
    {
        /// <summary>
        /// Get the userid of the user
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        string GetLoggedId(ClaimsPrincipal User);
        /// <summary>
        /// Get the particular order by using userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Order> GetCart(Guid userId);
        /// <summary>
        /// Get the particular orders based by using userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Order> GetOrder(Guid userId);
        /// <summary>
        /// Purchase the product
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        StatusDto Purchase(Guid userId,string token);
        /// <summary>
        /// Adding the product to the order
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="price"></param>
        /// <param name="quanityt"></param>
        /// <param name="productId"></param>
        void AddProduct(Guid userId,Guid productId,string price,int quanityt);


    }
}
