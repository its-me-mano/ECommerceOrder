using ECommerce_Additional.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Additional.Contracts.IRespositories
{
    public interface IOrderRepositories
    {
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
        /// Adding the product to the order
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        void AddProduct(Order order);
        /// <summary>
        /// Update the order
        /// </summary>
        /// <param name="order"></param>
        void UpdateOrder(Order order);
        /// <summary>
        /// udpate orders
        /// </summary>
        /// <param name="orders"></param>
        void UpdateOrders();
        /// <summary>
        /// get order by id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Order GetOrderById(Guid orderId);

        ///<summary>
        ///save the users
        ///</summary>
        bool Save();
    }
}
