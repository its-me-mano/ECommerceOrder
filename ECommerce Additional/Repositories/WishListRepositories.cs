using ECommerce_Additional.Contracts.IRespositories;
using ECommerce_Additional.DbContexts;
using ECommerce_Additional.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Additional.Repositories
{

    public class WishListRepositories : IWishListRepositories
    {
        private readonly UserCartContext _context;
        public WishListRepositories(UserCartContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Check the userid is in wishlist or not  
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool CheckWishList(Guid userId) {
            return _context.WishLists.Any(a => a.UserId == userId);
        }
        /// <summary>
        /// get the particular user wishlists
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<WishList> GetWishLists(Guid userId) {
            return _context.WishLists.Where(a => a.UserId == userId);
        }

        /// <summary>
        /// Add the wishlist 
        /// </summary>
        /// <param name="wishlist"></param>
        public void AddWishList(WishList wishlist) {
            _context.WishLists.Add(wishlist);
        }

        /// <summary>
        /// Get the particular wishlist using wishlistId
        /// </summary>
        /// <param name="wishlistId"></param>
        public WishList GetWishList(Guid wishlistId) {
            return _context.WishLists.Where(a => a.Id.Equals(wishlistId)).FirstOrDefault();
        }

        /// <summary>
        /// Adding the order table to order database
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(Order order) {
            _context.Orders.Add(order);
        }

        /// <summary>
        /// Delete the particular wishlist based on the wishlistId
        /// </summary>
        /// <param name="WishListId"></param>
        public void DeleteWishList(Guid WishListId) {
            WishList list = GetWishList(WishListId);
            _context.Remove(list);
        }

        /// <summary>
        /// Delete the Wishlist by the name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userId"></param>
        public void DeleteWishListByName(string name, Guid userId) {
            IEnumerable<WishList> list = GetWishListByName(name, userId);
            _context.RemoveRange(list);

        }

        /// <summary>
        /// Get the wislist based on userId and name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public  IEnumerable<WishList> GetWishListByName(string name, Guid userId)
        {
            return _context.WishLists.Where(a => a.UserId == userId && (a.Name).ToLower() == name.ToLower()).ToList();
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
