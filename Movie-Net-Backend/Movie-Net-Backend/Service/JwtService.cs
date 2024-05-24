using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Service.Interface;
using Org.BouncyCastle.Pqc.Crypto.Saber;

namespace Movie_Net_Backend.Service;

public class JwtService : IJwtService
{
    private static readonly TimeSpan TokenLifeSpan = TimeSpan.FromHours(4);

    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(LoginRequestDto loginRequest)
    {
        List<Claim> claims = new List<Claim>
        {
            new(ClaimTypes.Email, loginRequest.Email),
            new(ClaimTypes.Name, loginRequest.Email),
            new(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            // new(ClaimTypes.Role, "User")
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.Add(TokenLifeSpan),
            signingCredentials: credentials
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}