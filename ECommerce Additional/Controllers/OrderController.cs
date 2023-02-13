using AutoMapper;
using ECommerce_Additional.Contracts.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Additional.Controllers
{
    [ApiController]
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

      /*  [Authorize]
        [HttpGet("orders")]
        public IActionResult GetOrder() { 
            
        }*/
    }
}
