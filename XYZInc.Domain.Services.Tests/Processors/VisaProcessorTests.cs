using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;
using XYZInc.Domain.Services.Processors;
using XYZInc.Domain.Transaction;

namespace XYZInc.Domain.Services.Tests.Processors
{
    [ExcludeFromCodeCoverage]
    public class VisaProcessorTests
    {
        [Fact]
        public void VisaProcessor_should_return_receipt()
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
            VisaProcessor processor = new VisaProcessor();
            Receipt result = processor.Process(order);

            //Then
            Assert.NotNull(result);
            Assert.Equal(order.OrderNumber, result.OrderNumber);
        }
    }
}
