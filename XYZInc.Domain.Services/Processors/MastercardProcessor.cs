using System;
using XYZInc.Domain.Transaction;

namespace XYZInc.Domain.Services.Processors
{
    /// <summary>
    /// Mastercard processor
    /// </summary>
    public class MastercardProcessor : IOrderProcessor
    {
        public Receipt Process(Order order)
        {
            return new Receipt
            {
                CreationDate = DateTime.UtcNow,
                OrderNumber = order.OrderNumber,
                Status = OrderStatus.Success
            };
        }
    }
}
