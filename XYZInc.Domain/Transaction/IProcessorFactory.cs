namespace XYZInc.Domain.Transaction
{
    /// <summary>
    /// Processor factory
    /// </summary>
    public interface IProcessorFactory
    {
        IOrderProcessor CreateProcessor(PaymentGateway gateway);
    }
}
