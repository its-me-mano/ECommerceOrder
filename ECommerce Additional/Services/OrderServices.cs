using AutoMapper;
using ECommerce_Additional.Contracts.IRespositories;
using ECommerce_Additional.Contracts.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
