﻿using System;
using XYZInc.Domain.Transaction;

namespace XYZInc.Domain.Services.Processors
{
    public class UndefinedProcessor : IOrderProcessor
    {
        public Receipt Process(Order order)
        {
            return new Receipt
            {
                CreationDate = DateTime.UtcNow,
                OrderNumber = order.OrderNumber,
                Status = OrderStatus.Failed
            };
        }
    }
}
