using System.ComponentModel.DataAnnotations;

namespace XYZInc.Api.Models
{
    /// <summary>
    /// Create order request api model
    /// </summary>
    public class CreateOrderRequest
    {
        [Required]
        public string OrderNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public decimal PayableAmount { get; set; }

        [Required]
        public PaymentGatewayInfo PaymentGateway { get; set; }
        public string OptionalDescription { get; set; }
    }
}
