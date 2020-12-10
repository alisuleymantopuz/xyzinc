using System;

namespace XYZInc.Api.Models
{
    public class ReceiptModel
    {
        public DateTime CreationDate { get; set; }
        public string OrderNumber { get; set; }
        public OrderStatusInfo Status { get; set; }
    }
}
