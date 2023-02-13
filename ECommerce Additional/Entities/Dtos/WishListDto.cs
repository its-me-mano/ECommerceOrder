using ECommerce_Additional.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ECommerce_Additional.Entities.Dtos
{
    [DataContract]
    public class WishListDto
    {
        /// <summary>
        /// Wishlist Name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
        /// <summary>
        /// Wishlist of the products
        /// </summary>
        [DataMember(Name = "products")]
        public IEnumerable<ProductDto> products { get; set; } = new List<ProductDto>();
    }
}
