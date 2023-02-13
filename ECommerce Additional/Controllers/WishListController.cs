using AutoMapper;
using ECommerce_Additional.Contracts.IServices;
using ECommerce_Additional.Entities.Dtos;
using ECommerce_Additional.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Additional.Controllers
{
    [ApiController]
    [Route("api/account/wishlist")]
    public class WishListController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWishListServices _service;
        private readonly ILogger _logger;

        public WishListController(IMapper mapper, IWishListServices service,ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Authorize]
        [HttpGet("{user-id}")]
        public IActionResult GetUserWishList([FromRoute(Name = "user-id")][Required] Guid userId) {
            _logger.LogInformation("Fetching Wishlist has been initiated");
            if (!_service.CheckWishList(userId)) {
                _logger.LogError("userId does not exist in the wishlist");
                return StatusCode(404, "userId is not found");
            }
            IEnumerable<WishList> wishLists = _service.GetWishLists(userId);
            return StatusCode(200, wishLists);
        }

        [Authorize]
        [HttpPost("add/{product-id}")]
        public IActionResult AddProduct([FromRoute(Name = "product-id")][Required] Guid productId,[FromQuery(Name ="wishlist-name")] string wishlistName){
            _logger.LogInformation("Adding product has been initiated");
            Guid userId = new Guid(_service.GetLoggedId(User));
            _service.AddWishList(userId, productId,wishlistName);
            _logger.LogInformation("Product Added Successfully");
            return StatusCode(201, "Product added to the wishlist successfully");
        }

        [Authorize]
        [HttpPost("purchase/{wishlist-id}")]
        public IActionResult PurchaseProduct([FromRoute(Name = "wishlist-id")][Required] Guid wishlistId) {
            _logger.LogInformation("Purchase the product has been initiated");
            _service.AddToCart(wishlistId);
            return StatusCode(201, "Wishlist added to cart Successfully");
        }

        [Authorize]
        [HttpGet("getlist/{name}")]
        public IActionResult GetListByName([Required][FromRoute(Name = "name")]string name){
            _logger.LogInformation("GetListByNmae has been initiated");
            Guid userId = new Guid(_service.GetLoggedId(User));
            WishListDto wishlist = new WishListDto();
            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            wishlist.Name = name;
            IEnumerable<WishList> lists=_service.GetWishListByName(name,userId);
            wishlist.products = _service.GetProductsByWishList(lists,token);
            _logger.LogInformation("Fetched the List successfully");
            return StatusCode(200, new JsonResult(lists));
        }

        [Authorize]
        [HttpDelete("{wishlist-id}")]
        public IActionResult DeleteWishList([Required][FromRoute(Name = "wishlist-id")] Guid WishListId) {
            _logger.LogInformation("Delete process has been initiated");
            Guid userId = new Guid(_service.GetLoggedId(User));
            _service.DeleteWishList(WishListId);
            return StatusCode(200, "WishList has been deleted successfully");
        }

        [Authorize]
        [HttpDelete("/deletelist/{name}")]
        public IActionResult DeleteWishLists([Required][FromRoute(Name = "name")] string name) {
            _logger.LogInformation("Deleting the list process has been initiated");
            Guid userId = new Guid(_service.GetLoggedId(User));
            _service.DeleteListByName(name, userId);
            return StatusCode(200, $"WishList with the name {name} has been deleted successfully");
            
        }
       
    }
}
