namespace XYZInc.Domain.Transaction
{
    public interface IProcessorFactory
    {
        IOrderProcessor CreateProcessor(PaymentGateway gateway);
    }
}
