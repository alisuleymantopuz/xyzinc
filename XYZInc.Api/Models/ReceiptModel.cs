using System;

namespace XYZInc.Api.Models
{
    /// <summary>
    /// Receipt model
    /// </summary>
    public class ReceiptModel
    {
        public DateTime CreationDate { get; set; }
        public string OrderNumber { get; set; }
        public OrderStatusInfo Status { get; set; }
    }
}
