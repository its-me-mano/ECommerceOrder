using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ECommerce_Additional.Entities.Models
{
    [DataContract]
    public class WishList
    {
        /// <summary>
        /// Id of the wishlist
        /// </summary>
        [DataMember(Name = "id")]
        public Guid Id { get; set; }
        /// <summary>
        /// user id of the wishlist 
        /// </summary>
        [DataMember(Name = "user_id")]
        public Guid UserId { get; set; }
        /// <summary>
        /// Wishlist Name
        /// </summary>
        [DataMember(Name ="name")]
        public string Name { get; set; }
        /// <summary>
        /// Wishlist of the productId
        /// </summary>
        [DataMember(Name = "product_id")]
        public Guid ProductId { get; set; }
    }
}
