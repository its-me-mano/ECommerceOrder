using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Additional.Entities.Dtos
{
    public class OrderDto
    {
        /// <summary>
        /// id of the order
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        /// <summary>
        /// userid of the user who ordered
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Productid which has he ordered
        /// </summary>
        [JsonProperty(PropertyName = "product_id")]
        public Guid ProductId { get; set; }
        /// <summary>
        ///Howmany of the product he bought
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
        /// <summary>
        /// Overall price of the product
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public float Price { get; set; }
        /// <summary>
        /// What is the payment method he is ued
        /// </summary>
        [JsonProperty(PropertyName = "payment_method")]
        public string PaymentMethod { get; set; }
        /// <summary>
        /// What is the time he paid
        /// </summary>
        [JsonProperty(PropertyName = "payment_time")]
        public DateTime PaymentTime { get; set; }
        /// <summary>
        /// Check the table is purchased or not
        /// </summary>
        [JsonProperty(PropertyName = "isorder")]
        public bool IsOrder { get; set; }
    }
}
