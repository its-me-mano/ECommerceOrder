using AutoMapper;
using ECommerce_Additional.Contracts.IRespositories;
using ECommerce_Additional.Contracts.IServices;
using ECommerce_Additional.Entities.Dto;
using ECommerce_Additional.Entities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce_Additional.Services
{
    public class WishListServices : IWishListServices
    {
        private readonly IWishListRepositories _repositories;
        private readonly IMapper _mapper;

        public WishListServices(IWishListRepositories repositories, IMapper mapper)
        {
            _repositories = repositories ?? throw new ArgumentNullException(nameof(repositories));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        /// <summary>
        /// Check the userid is in wishlist or not  
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool CheckWishList(Guid userId) {
            return _repositories.CheckWishList(userId);
        }
        /// <summary>
        /// Get the particular user wishlist
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<WishList> GetWishLists(Guid userId) {
            return _repositories.GetWishLists(userId);
        }

        /// <summary>
        /// Get the userid of the user
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public string GetLoggedId(ClaimsPrincipal User) {
                string LoggedUserId = String.Empty;
            if (!String.IsNullOrEmpty(ClaimTypes.NameIdentifier))
                LoggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return LoggedUserId;
        }
        /// <summary>
        /// Check the product does exist or not
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool CheckProductExist(Guid productId, string token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            return true;
        }
        /// <summary>
        /// Add the product to the wishlist
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="userId"></param>
        /// <param name="wishlistName"></param>
        public void AddWishList(Guid userId, Guid productId,string wishlistName) {
            WishList wishList = new WishList();
            wishList.UserId = userId;
            wishList.ProductId = productId;
            wishList.Name = wishlistName;
            _repositories.AddWishList(wishList);
            _repositories.Save();
        }

        /// <summary>
        /// Add the product to the cart
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        public void AddToCart(Guid wishlistId) {
            WishList wishlist = _repositories.GetWishList(wishlistId);
            Order order = _mapper.Map<Order>(wishlist);
            order.IsOrder = true;
            order.Quantity = 1;
            _repositories.AddOrder(order);
            _repositories.Save();
        }

        /// <summary>
        /// Get the wislist based on userId and name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<WishList> GetWishListByName(string name, ClaimsPrincipal user) {
            Guid userId = new Guid(GetLoggedId(user));
            return _repositories.GetWishListByName(name, userId);
        }

        /// <summary>
        /// Delete the particular wishlist based on the wishlistId
        /// </summary>
        /// <param name="WishListId"></param>
        public void DeleteWishList(Guid WishListId) {
            _repositories.DeleteWishList(WishListId);
            _repositories.Save();        
        }


        /// <summary>
        /// Get the productIds from wishlists
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public List<Guid> GetGuidFromWishList(IEnumerable<WishList> lists) {
            List<Guid> ids = new List<Guid>();
            foreach (WishList list in lists) {
                ids.Add(list.ProductId);
            }
            return ids;
        }
        /// <summary>
        /// Get the products by wishlist
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public IEnumerable<ProductDto> GetProductsByWishList(IEnumerable<WishList> lists,string token) {
    
            var queryString = string.Join("&",lists.Select(g => $"{g.ProductId}"));
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            IEnumerable<ProductDto> response = client.GetFromJsonAsync<List<ProductDto>>($"http://localhost:20438/api/account/product/getproducts?queryString={queryString}").Result;
            return response;
        }

        /// <summary>
        /// Delete the wishlist by the name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userId"></param>
        public void DeleteListByName(String name, Guid userId) {
            _repositories.DeleteWishListByName(name, userId);
            _repositories.Save();
        }
    }
}
