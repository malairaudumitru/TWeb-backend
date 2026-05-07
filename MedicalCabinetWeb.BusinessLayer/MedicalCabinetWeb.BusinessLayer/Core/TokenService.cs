using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MedicalCabinetWeb.BusinessLayer.Core;

public class TokenService
{
    public TokenService() { }
    
    public string GenerateToken(int userId, string firstName, string lastName, string role)
    {
        var key   = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name,           $"{firstName} {lastName}"),
            new Claim(ClaimTypes.Role,           role)
        };

        var token = new JwtSecurityToken(
            issuer:             JwtSettings.Issuer,
            audience:           JwtSettings.Audience,
            claims:             claims,
            expires:            DateTime.UtcNow.AddMinutes(JwtSettings.ExpireMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
}