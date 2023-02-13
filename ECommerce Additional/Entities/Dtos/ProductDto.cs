using System;
using System.Runtime.Serialization;


namespace ECommerce_Additional.Entities.Dto
{
    public class ProductDto
    {
        /// <summary>
        /// Product Id
        /// </summary>
        [DataMember(Name = "id")]
        public Guid Id { get; set; }
        /// <summary>
        /// Product Name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
        /// <summary>
        /// Product Quantity
        /// </summary>
        [DataMember(Name = "product_count")]
        public int ProductCount { get; set; }
        /// <summary>
        /// Price of the  product
        /// </summary>
        [DataMember(Name = "price")]
        public float Price { get; set; }
        /// <summary>
        /// Visibility of the product
        /// </summary>
        [DataMember(Name = "visibility")]
        public Guid Visibility { get; set; }
        /// <summary>
        /// Product Image
        /// </summary>
        [DataMember(Name = "image_asset")]
        public Guid ImageAsset { get; set; }
        /// <summary>
        /// Category of the product
        /// </summary>
        [DataMember(Name = "category")]
        public Guid Category { get; set; }
    }
}
