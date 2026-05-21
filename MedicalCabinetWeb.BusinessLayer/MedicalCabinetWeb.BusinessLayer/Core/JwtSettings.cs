namespace MedicalCabinetWeb.BusinessLayer.Core;

public static class JwtSettings
{
    public const string Issuer = "MedicalCabinetApi";
    public const string Audience = "MedicalCabinetClients";
    public const int ExpireMinutes = 60;
    public static string SecretKey =>
        Environment.GetEnvironmentVariable("JWT_SECRET_KEY")
        ?? throw new InvalidOperationException("JWT_SECRET_KEY not configured.");
}
