using System.Diagnostics.CodeAnalysis;
using Xunit;
using XYZInc.Domain.Services.Processors;
using XYZInc.Domain.Transaction;

namespace XYZInc.Domain.Services.Tests
{
    [ExcludeFromCodeCoverage]
    public class ProcessorFactoryTests
    {
        [Theory]
        [InlineData(PaymentGateway.Mastercard)]
        [InlineData(PaymentGateway.Visa)]
        [InlineData(PaymentGateway.Other)]
        public void CreateProcessor_should_return_processor(PaymentGateway paymentGateway)
        {
            //Given : paymentGateway parameter

            //When
            var result = new ProcessorFactory().CreateProcessor(paymentGateway);

            //Then
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateProcessor_should_return_visaprocessor_by_visapaymentgateway()
        {
            //Given 
            var type = PaymentGateway.Visa;

            //When
            var result = new ProcessorFactory().CreateProcessor(type);

            //Then
            Assert.IsType<VisaProcessor>(result);
        }
    }
}
