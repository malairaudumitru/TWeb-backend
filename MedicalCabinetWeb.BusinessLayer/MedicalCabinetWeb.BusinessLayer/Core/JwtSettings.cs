namespace MedicalCabinetWeb.BusinessLayer.Core;

public static class JwtSettings
{
    public const string Issuer = "MedicalCabinetApi";
    public const string Audience = "MedicalCabinetClients";
    public const string SecretKey = "awdawfanjAWDAWDSADAWDAgadsadwadasczca";
    public const int ExpireMinutes = 60;
}
