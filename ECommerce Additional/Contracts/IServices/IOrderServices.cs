using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce_Additional.Contracts.IServices
{
    public interface IOrderServices
    {
        /// <summary>
        /// Get the userid of the user
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        string GetLoggedId(ClaimsPrincipal User);
    }
}
