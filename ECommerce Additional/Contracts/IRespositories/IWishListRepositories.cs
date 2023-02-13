    using ECommerce_Additional.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Additional.Contracts.IRespositories
{
    public interface IWishListRepositories
    {
        /// <summary>
        /// Check whether the wishlist has there or not
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool CheckWishList(Guid userId);
        /// <summary>
        /// get the particular user wishlists
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<WishList> GetWishLists(Guid userId);

        /// <summary>
        /// Add the wishlist 
        /// </summary>
        /// <param name="wishlist"></param>
        void AddWishList(WishList wishlist);
        /// <summary>
        /// Get the particular wishlist using wishlistId
        /// </summary>
        /// <param name="wishlistId"></param>
        WishList GetWishList(Guid wishlistId);
        /// <summary>
        /// Adding the order table to order database
        /// </summary>
        /// <param name="order"></param>
        void AddOrder(Order order);
        /// <summary>
        /// Get the wislist based on userId and name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<WishList> GetWishListByName(string name, Guid userId);
        /// <summary>
        /// Delete the particular wishlist based on the wishlistId
        /// </summary>
        /// <param name="WishListId"></param>
        void DeleteWishList(Guid WishListId);
        /// <summary>
        /// Delete the Wishlist by the name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userId"></param>
        void DeleteWishListByName(string name,Guid userId);

        ///<summary>
        ///save the users
        ///</summary>
        bool Save();
    }
}
