using AutoMapper;
using ECommerce_Additional.Contracts.IRespositories;
using ECommerce_Additional.Contracts.IServices;
using ECommerce_Additional.Entities.Dto;
using ECommerce_Additional.Entities.Dtos;
using ECommerce_Additional.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce_Additional.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepositories _orderRepo;
        private readonly IMapper _mapper;
        public OrderServices(IOrderRepositories repositories,IMapper mapper)
        {
            _mapper = mapper;
            _orderRepo = repositories;
        }


        /// <summary>
        /// Get the userid of the user
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public string GetLoggedId(ClaimsPrincipal User)
        {
            string LoggedUserId = String.Empty;
            if (!String.IsNullOrEmpty(ClaimTypes.NameIdentifier))
                LoggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return LoggedUserId;
        }

        /// <summary>
        /// Get the particular order by using userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Order> GetCart(Guid userId) {
            return _orderRepo.GetCart(userId);
        }

        /// <summary>
        /// Get the particular orders based by using userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Order> GetOrder(Guid userId) {
            return _orderRepo.GetOrder(userId);
        }

        /// <summary>
        /// Adding the product to the order
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        public void AddProduct(Guid userId, Guid productId,string price,int quantity) {
            Order order = new Order();
            order.ProductId = productId;
            order.Price = float.Parse(price);
            order.UserId = userId;
            order.Quantity = quantity;
            order.IsOrder = true;
            _orderRepo.AddProduct(order);
            _orderRepo.Save();
        }

        /// <summary>
        /// Purchase the product
        /// </summary>
        /// <param name="userId"></param>
        public StatusDto Purchase(Guid userId,string token) {
            StatusDto status = new StatusDto();

            IEnumerable<Order> orders = _orderRepo.GetCart(userId);
            List<OrderDto> orderDtos = new List<OrderDto>();
            _mapper.Map(orders, orderDtos);
            if (orders == null) {
                status.StatusCode = "404";
                status.Description = "There is no product available in cart";
                return status;
            }
            foreach (OrderDto order in orderDtos) {
                int quantity = order.Quantity;
                Guid productId = order.ProductId;
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                bool response = client.GetFromJsonAsync<bool>($"http://localhost:20438/api/account/product/countcheck/?quantity={quantity}&product-id={productId}").Result;
                if (!response)
                {
                    status.StatusCode = "404";
                    status.Description = $"{productId} is not availble. Reduce the quantity";
                    return status;
                }
                else {
                    order.IsOrder = true;
                
                }
            }
            _orderRepo.Save();
            status.StatusCode = "200";
            return status;

        }
    }
}
