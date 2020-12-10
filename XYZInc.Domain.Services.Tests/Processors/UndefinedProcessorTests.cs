using System;
using Xunit;
using XYZInc.Domain.Services.Processors;
using XYZInc.Domain.Transaction;

namespace XYZInc.Domain.Services.Tests.Processors
{
    public class UndefinedProcessorTests
    {
        [Fact]
        public void UndefinedProcessor_should_return_receipt_withfailure()
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
            var result = new UndefinedProcessor().Process(order);

            //Then
            Assert.NotNull(result);
            Assert.Equal(order.OrderNumber, result.OrderNumber);
            Assert.Equal(OrderStatus.Failed, result.Status);
        }
    }
}
