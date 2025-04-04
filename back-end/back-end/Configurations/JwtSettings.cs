namespace back_end.Configurations;

public class JwtSettings
{
    public string SecretKey { get; set; } = "";
    public string Audience { get; set; } = "";
    public string Issuer { get; set; } = "";
}