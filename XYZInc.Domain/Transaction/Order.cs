using System.Diagnostics.CodeAnalysis;

namespace XYZInc.Domain.Transaction
{
    /// <summary>
    /// Order domain
    /// </summary>
    [ExcludeFromCodeCoverage]

    public class Order
    {
        public string OrderNumber { get; set; }
        public string UserId { get; set; }
        public decimal PayableAmount { get; set; }
        public PaymentGateway PaymentGateway { get; set; }
        public string OptionalDescription { get; set; }
    }
}
