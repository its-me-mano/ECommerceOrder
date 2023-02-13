using AutoMapper;
using ECommerce_Additional.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Additional.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<WishList, Order>().ReverseMap();

        }
    }
}
