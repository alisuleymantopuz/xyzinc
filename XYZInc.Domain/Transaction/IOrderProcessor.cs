namespace XYZInc.Domain.Transaction
{
    /// <summary>
    /// Order processor contract
    /// </summary>
    public interface IOrderProcessor
    {
        Receipt Process(Order order);
    }
}
