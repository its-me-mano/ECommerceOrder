using ECommerce_Additional.Contracts.IRespositories;
using ECommerce_Additional.DbContexts;
using ECommerce_Additional.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Additional.Repositories
{
    public class OrderRepositories : IOrderRepositories
    {
        private readonly UserCartContext _context;

        public OrderRepositories(UserCartContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get the particular order by using userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Order> GetCart(Guid userId)
        {
            return _context.Orders.Where(a => a.UserId == userId && a.IsOrder == false);
        }

        /// <summary>
        /// Get the particular orders based by using userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Order> GetOrder(Guid userId)
        {
            return _context.Orders.Where(a => a.UserId == userId && a.IsOrder == true);
        }
        /// <summary>
        /// get order by id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order GetOrderById(Guid orderId) {
            return _context.Orders.Where(a => a.Id == orderId).FirstOrDefault();
        }

        /// <summary>
        /// Adding the product to the order
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        public void AddProduct(Order order)
        {
            _context.Orders.Add(order);
        }

        /// <summary>
        /// Update the order
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOrder(Order order)
        {
          
        }

        /// <summary>
        /// udpate orders
        /// </summary>
        public void UpdateOrders()
        {

        }
        ///<summary>
        ///save the data
        ///</summary>
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
