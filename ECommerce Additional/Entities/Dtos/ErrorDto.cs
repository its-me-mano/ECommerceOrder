
using Newtonsoft.Json;

namespace ECommerce_Additional.Entities.Dto
{
    public class ErrorDto
    {
        /// <summary>
        /// status code of the error
        /// </summary>
        [JsonProperty(PropertyName = "status_code")]
        public string StatusCode { get; set; }
        /// <summary>
        /// error type
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        /// <summary>
        /// error details
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
