namespace XYZInc.Domain.Security
{
    public interface IAuthenticationManager
    {
        bool ValidateUser(string userName, string email, string password);
        object GenerateToken(string userName, string email);
    }
}
