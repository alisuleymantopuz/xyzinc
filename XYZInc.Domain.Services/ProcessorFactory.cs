using XYZInc.Domain.Services.Processors;
using XYZInc.Domain.Transaction;

namespace XYZInc.Domain.Services
{
    public class ProcessorFactory : IProcessorFactory
    {
        public IOrderProcessor CreateProcessor(PaymentGateway gateway)
        {
            switch (gateway)
            {
                case PaymentGateway.Visa:
                    return new VisaProcessor();
                case PaymentGateway.Mastercard:
                    return new MastercardProcessor();
                default:
                    return new UndefinedProcessor();
            }
        }
    }
}
