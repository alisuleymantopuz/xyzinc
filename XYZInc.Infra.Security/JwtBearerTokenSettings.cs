namespace XYZInc.Infra.Security
{
    /// <summary>
    /// Jwt bearer token settings value object model
    /// </summary>
    public class JwtBearerTokenSettings
    {
        public string SecretKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpiryTimeInSeconds { get; set; }
    }
}
