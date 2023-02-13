using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ECommerce_Additional.Entities.Models
{
    [DataContract]
    public class Order
    {
        /// <summary>
        /// id of the order
        /// </summary>
        [DataMember(Name = "id")]
        public Guid Id { get; set; }
        /// <summary>
        /// userid of the user who ordered
        /// </summary>
        [DataMember(Name = "user_id")]
        public Guid UserId { get; set; }
        /// <summary>
        /// Productid which has he ordered
        /// </summary>
        [DataMember(Name = "product_id")]
        public Guid ProductId { get; set; }
        /// <summary>
        ///Howmany of the product he bought
        /// </summary>
        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }
        /// <summary>
        /// Overall price of the product
        /// </summary>
        [DataMember(Name = "price")]
        public float Price { get; set; }
        /// <summary>
        /// What is the payment method he is ued
        /// </summary>
        [DataMember(Name = "payment_method")]
        public string PaymentMethod { get; set; }
        /// <summary>
        /// What is the time he paid
        /// </summary>
        [DataMember(Name = "payment_time")]
        public DateTime PaymentTime { get; set; }
        /// <summary>
        /// Check the table is purchased or not
        /// </summary>
        [DataMember(Name = "isorder")]
        public bool IsOrder { get; set; }
    }
}
