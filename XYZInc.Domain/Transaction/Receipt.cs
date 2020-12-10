using System;
using System.Diagnostics.CodeAnalysis;

namespace XYZInc.Domain.Transaction
{
    /// <summary>
    /// Receipt domain
    /// </summary>
    [ExcludeFromCodeCoverage]

    public class Receipt
    {
        public DateTime CreationDate { get; set; }
        public string OrderNumber { get; set; }
        public OrderStatus Status { get; set; }
    }
}
