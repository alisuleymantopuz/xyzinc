namespace XYZInc.Domain.Security
{
    /// <summary>
    /// Authentication manager contract
    /// </summary>
    public interface IAuthenticationManager
    {
        bool ValidateUser(string userName, string email, string password);
        object GenerateToken(string userName, string email);
    }
}
