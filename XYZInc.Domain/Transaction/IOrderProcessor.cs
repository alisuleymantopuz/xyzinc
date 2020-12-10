namespace XYZInc.Domain.Transaction
{
    public interface IOrderProcessor
    {
        Receipt Process(Order order);
    }
}
