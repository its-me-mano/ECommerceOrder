using AutoMapper;
using ECommerce_Additional.Entities.Dtos;
using ECommerce_Additional.Entities.Models;
using System.Collections;
using System.Collections.Generic;

namespace ECommerce_Additional.Profiles
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<WishList, Order>().ReverseMap();
            CreateMap<Order, Order>();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<List<OrderDto>, List<Order>>().ReverseMap();

        }
    }
}
