using ECommerce_Additional.Entities.Dto;
using ECommerce_Additional.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce_Additional.Contracts.IServices
{
    public interface IWishListServices 
    {
        /// <summary>
        /// Check the userid is in wishlist or not  
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool CheckWishList(Guid userId);
        /// <summary>
        /// Get the particular user wishlist
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<WishList> GetWishLists(Guid userId);
        /// <summary>
        /// Get the userid of the user
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        string GetLoggedId(ClaimsPrincipal User);
        /// <summary>
        /// Add the product to the wishlist
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        void AddWishList(Guid userId,Guid productId,string wishlistName);
        /// <summary>
        /// Get the wislist based on userId and name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<WishList> GetWishListByName(string name,ClaimsPrincipal user);
        /// <summary>
        /// Delete the particular wishlist based on the wishlistId
        /// </summary>
        /// <param name="WishListId"></param>
        void DeleteWishList(Guid WishListId);
        /// <summary>
        /// Add the product to the cart
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        void AddToCart(Guid wishlistId);
        /// <summary>
        /// Get the productIds from wishlists
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        List<Guid> GetGuidFromWishList(IEnumerable<WishList> lists);
        /// <summary>
        /// Get the products by wishlist
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        IEnumerable<ProductDto> GetProductsByWishList(IEnumerable<WishList> lists, string token);
        /// <summary>
        /// Delete the wishlist by the name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userId"></param>
        void DeleteListByName(String name, Guid userId);


    }
}
