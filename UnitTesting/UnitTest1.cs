using AutoMapper;
using ECommerce_Additional.Controllers;
using ECommerce_Additional.DbContexts;
using ECommerce_Additional.Repositories;
using ECommerce_Additional.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ECommerce_Additional.Profiles;
using System;
using System.Security.Claims;
using Xunit;
using ECommerce_Additional.InMemoryContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Moq;
using ECommerce_Additional.Contracts.IServices;
using System.Collections;
using System.Collections.Generic;
using ECommerce_Additional.Entities.Models;
using ECommerce_Additional.Entities.Dto;

namespace UnitTesting
{

    public class UnitTest1
    {
        OrderServices orderServices;
        WishListServices WishListServices;
        OrderRepositories orderRepositories;
        WishListRepositories wishListRepositories;
        OrderController orderController;
        WishListController WishListController;
        UserCartContext context;
        IMapper _mapper;
        private readonly IConfiguration configuration;
        private ClaimsPrincipal user;
        private Guid userId;
        private WishListController Mockcontroller;
        private OrderController MockOrderController;
        string token;
        public UnitTest1()
        {
            configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

            userId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be");

            user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier,userId.ToString()),
                                        new Claim(ClaimTypes.Role,"Admin")
                           }, "TestAuthentication")); ;

            using var services = new ServiceCollection().AddSingleton<IConfiguration>(configuration).BuildServiceProvider();
            context = InMemorydbContext.userCartContext();
            IHostBuilder hostBuilder = Host.CreateDefaultBuilder().
            ConfigureLogging((builderContext, loggingBuilder) =>
            {
                loggingBuilder.AddConsole((options) =>
                {
                    options.IncludeScopes = true;
                });
            });
            IHost host = hostBuilder.Build();
            ILogger<WishListController> logger1 = host.Services.GetRequiredService<ILogger<WishListController>>();
            ILogger<OrderController> logger2 = host.Services.GetRequiredService<ILogger<OrderController>>();
            token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOlsiNjg0MTc3NDgtNjg2NC00ODY2LThkOWItYjgyYWUyOWRhMzk2IiwiS3VtYXIiLCJVc2VyIl0sImp0aSI6IjdjN2ZmOWRkLTEwMDEtNDQwMy04Y2ZkLTk2NmZhNDNkYTc1YiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJleHAiOjE2NzY3OTA4NzksImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTYwNzciLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjU2MDc3In0.yMAb0rsjwjxwxg8iGFtBt0XVNTIn6RHSbkuhGXGZWc8";
            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Automapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
            wishListRepositories = new WishListRepositories(context);
            WishListServices = new WishListServices(wishListRepositories,mapper);
            WishListController = new WishListController(mapper, WishListServices, logger1);
            orderRepositories = new OrderRepositories(context);
            orderServices = new OrderServices(orderRepositories, mapper);
            orderController = new OrderController(mapper, orderServices, logger2);
            orderController.ControllerContext = new ControllerContext();
            orderController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            WishListController.ControllerContext = new ControllerContext();
            WishListController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            Mock<IWishListServices> mockservice = new Mock<IWishListServices>();
            Mock<IOrderServices> mockorderservice = new Mock<IOrderServices>();
            List<WishList> list = new List<WishList>(){new WishList()
            {
                Id = new Guid("698f8b7b-65d2-4425-b724-46c076943f17"),
                UserId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                ProductId = new Guid("2b6aa7d6-1974-430f-a760-3ced549d0471"),
                Name = "mobiles"
            } };
            StatusDto status = new StatusDto() { StatusCode = "200" };
            mockorderservice.Setup(a => a.Purchase(userId, token)).Returns(status);
            mockservice.Setup(a => a.GetWishListByName("manoj", user)).Returns(list);
            mockservice.Setup(a => a.GetLoggedId(user)).Returns("698f8b7b - 65d2 - 4425 - b724 - 46c076943f17");
/*            mockservice.Verify(a => a.GetLoggedId(user), Times.Once);
*/            Mockcontroller = new WishListController(mapper,mockservice.Object,logger1);
            MockOrderController = new OrderController(mapper, mockorderservice.Object, logger2);
            
            Mock<HttpContext> contextMock = new Mock<HttpContext>();
            contextMock.Setup(x => x.User).Returns(new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier,userId.ToString()),
                                        new Claim(ClaimTypes.Role,"admin")
                                        // other required and custom claims
                           }, "TestAuthentication")));
            Mockcontroller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            MockOrderController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            
        }
        [Fact]
        public void GetUserWishList_Ok()
        {
            IActionResult Response = WishListController.GetUserWishList(userId);
            Assert.Equal(200, (Response as ObjectResult).StatusCode);
        }

        [Fact]
        public void GetUserWishList_NotFound() {
            userId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be01e");
            IActionResult Response = WishListController.GetUserWishList(userId);
            Assert.Equal(404, (Response as ObjectResult).StatusCode);
        }

        [Fact]
        public void AddProduct_Created() {
            Guid productId = new Guid("8de4b55d-80d2-4313-9367-de5c561ef331");
            IActionResult response = WishListController.AddProduct(productId, "manoj");
            Assert.Equal(201, (response as ObjectResult).StatusCode);

        }

        [Fact]
        public void PurchaseProduct() {
            Guid wishListId = new Guid("698f8b7b-65d2-4425-b724-46c076943f17");
            IActionResult response = WishListController.PurchaseProduct(wishListId);
            Assert.Equal(201, (response as ObjectResult).StatusCode);
        }

        [Fact]
        public void GetListByName_NotFound() {
            Mockcontroller.ControllerContext.HttpContext.Request.Headers.Add("Authorization", new string[] { $"Bearer {token}"});
            IActionResult response = Mockcontroller.GetListByName("mobiles");
            Assert.Equal(404, (response as ObjectResult).StatusCode);
        }

        [Fact]
        public void DeleteWishList_Ok() {
            Guid wishListId = new Guid("698f8b7b-65d2-4425-b724-46c076943f17");
            IActionResult response = WishListController.DeleteWishList(wishListId);
            Assert.Equal(200, (response as ObjectResult).StatusCode);
        }


        [Fact]
        public void GetCart_Ok() {
            IActionResult response = orderController.GetCart();
            Assert.Equal(200, (response as ObjectResult).StatusCode);
        }

        [Fact]
        public void GetOrder_Ok()
        {
            IActionResult response = orderController.GetOrder();
            Assert.Equal(200, (response as ObjectResult).StatusCode);
        }

        [Fact]
        public void addproudct_Ok() {
           string productId = "8de4b55d-80d2-4313-9367-de5c561ef331";
            IActionResult response = orderController.AddProduct(productId,"100",1);
            Assert.Equal(200, (response as ObjectResult).StatusCode);
        }

      


    }
}
