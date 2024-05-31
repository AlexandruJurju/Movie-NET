using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class JwtService(IConfiguration configuration, IUserService userService) : IJwtService
{
    private static readonly TimeSpan TokenLifeSpan = TimeSpan.FromHours(4);

    public async Task<string> GenerateToken(LoginRequestDto loginRequest)
    {
        var userResult = await userService.FindUserByEmailAsync(loginRequest.Email);
        if (userResult.IsFailed) throw new Exception(userResult.Errors.ToString());

        var user = userResult.Value;
        var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")!);

        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, user.Username),
            new(JwtRegisteredClaimNames.Email, user.Email),
        };

        // todo: make it so user can have multiple roles
        claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(TokenLifeSpan),
            Issuer = configuration["JwtSettings:Issuer"],
            Audience = configuration["JwtSettings:Audience"],
            SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }
}