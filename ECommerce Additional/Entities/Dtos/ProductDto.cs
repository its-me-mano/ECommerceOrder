using System;
using System.Runtime.Serialization;


namespace ECommerce_Additional.Entities.Dto
{
    public class ProductDto
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Product Quantity
        /// </summary>
        public int ProductCount { get; set; }
        /// <summary>
        /// Price of the  product
        /// </summary>

        public float Price { get; set; }
        /// <summary>
        /// Visibility of the product
        /// </summary>

        public Guid Visibility { get; set; }
        /// <summary>
        /// Product Image
        /// </summary>

        public Guid ImageAsset { get; set; }
        /// <summary>
        /// Category of the product
        /// </summary>

        public Guid Category { get; set; }
    }
}
