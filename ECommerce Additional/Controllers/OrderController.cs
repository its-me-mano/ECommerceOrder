    using AutoMapper;
using ECommerce_Additional.Contracts.IServices;
using ECommerce_Additional.Entities.Dto;
using ECommerce_Additional.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Additional.Controllers
{
    [ApiController]
    [Route("api/account/order")]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderServices _orderservices;
        private readonly ILogger _logger;
        public OrderController(IMapper mapper,IOrderServices orderServices,ILogger logger)
        {
            _logger = logger;
            _mapper = mapper;
            _orderservices = orderServices;
        }



        /// <summary>
        /// Cart Check
        /// </summary>
        /// <remarks>Fetch Cart</remarks>
        /// <response code="200">carts fetched successfully</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="403">user doesn't have permisssion to access this resource</response>
        [SwaggerOperation("GetCart")]
        [SwaggerResponse(statusCode: 200, "carts fetched successfully")]
        [SwaggerResponse(statusCode: 401, "The user  is not authorized", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 403, "user doesn't have permisssion to access this resource")]
        [Authorize]
        [HttpGet("cart")]
        public IActionResult GetCart()
        {
            _logger.LogInformation("Get cart has been initiated");
            Guid userId = new Guid(_orderservices.GetLoggedId(User));
            IEnumerable<Order> orders=_orderservices.GetCart(userId);
            _logger.LogInformation("cart has been fetched successfully");
            return StatusCode(200, orders);
        }

        /// <summary>
        /// Get Order
        /// </summary>
        /// <remarks>Get the orderss</remarks>
        /// <response code="200">orders fetched successfully</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="403">user doesn't have permisssion to access this resource</response>
        [SwaggerOperation("GetOrder")]
        [SwaggerResponse(statusCode: 200, "orders fetched successfully")]
        [SwaggerResponse(statusCode: 401, "The user  is not authorized", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 403, "user doesn't have permisssion to access this resource")]
        [Authorize]
        [HttpGet("getorders")]
        public IActionResult GetOrder() {
            _logger.LogInformation("Get the order has been initiated");
            Guid userId = new Guid(_orderservices.GetLoggedId(User));
            IEnumerable<Order> orders = _orderservices.GetOrder(userId);
            _logger.LogInformation("order has been fetched successfully");
            return StatusCode(200, orders);
        }


        /// <summary>
        /// AddProduct
        /// </summary>
        /// <remarks>Add product to cart</remarks>
        /// <param name="price"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <response code="200">Products added successfully</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="403">user doesn't have permisssion to access this resource</response>
        [SwaggerOperation("AddProduct")]
        [SwaggerResponse(statusCode: 200, "products added successfully")]
        [SwaggerResponse(statusCode: 401, "The user  is not authorized", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 403, "user doesn't have permisssion to access this resource")]
        [Authorize]
        [HttpPost("addproduct")]
        public IActionResult AddProduct([FromQuery(Name ="product-id")]string productId,[FromQuery (Name ="price")] string price,[FromQuery(Name ="quantity")] int quantity) {
            _logger.LogInformation("Adding product has been initiated");
            Guid userId = new Guid(_orderservices.GetLoggedId(User));
            _orderservices.AddProduct(userId,new Guid(productId),price,quantity);
            return StatusCode(200, "Product added successfully");
        }


        /// <summary>
        /// purchase Products
        /// </summary>
        /// <remarks>Purchase Product</remarks>
        /// <response code="200">purchased successfully</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="403">user doesn't have permisssion to access this resource</response>
        [SwaggerOperation("Purchase")]
        [SwaggerResponse(statusCode: 200, "Purchased successfully")]
        [SwaggerResponse(statusCode: 401, "The user  is not authorized", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 403, "user doesn't have permisssion to access this resource")]
        [Authorize]
        [HttpPost("purchase")]
        public IActionResult Purchase()
        {
            _logger.LogInformation("Purchase has been initiated successfully");
            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            Guid userId = new Guid(_orderservices.GetLoggedId(User));
            StatusDto status=_orderservices.Purchase(userId,token);
            if (status.StatusCode == "200")
            {
                return StatusCode(200, "Purchased successfully");
            }
            else {
                return StatusCode(404, status.Description);
            }
        }
    }
}
