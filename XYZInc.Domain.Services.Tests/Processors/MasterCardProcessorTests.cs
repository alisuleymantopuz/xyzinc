﻿using System;
using Xunit;
using XYZInc.Domain.Services.Processors;
using XYZInc.Domain.Transaction;

namespace XYZInc.Domain.Services.Tests.Processors
{
    public class MasterCardProcessorTests
    {
        [Fact]
        public void MasterCardProcessor_should_return_receipt()
        {
            //Given
            var order = new Order
            {
                OptionalDescription = "description",
                OrderNumber = Guid.NewGuid().ToString(),
                PayableAmount = 12.2m,
                PaymentGateway = PaymentGateway.Visa,
                UserId = Guid.NewGuid().ToString()
            };

            //When
            var result = new MastercardProcessor().Process(order);

            //Then
            Assert.NotNull(result);
            Assert.Equal(order.OrderNumber, result.OrderNumber);
        }
    }
}
