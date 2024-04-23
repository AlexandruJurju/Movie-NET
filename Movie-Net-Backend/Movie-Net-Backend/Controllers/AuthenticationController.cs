using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Movie_Net_Backend.Dto;

namespace Movie_Net_Backend.Controllers;

[Route("api/v1/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;

    private static readonly TimeSpan TokenLifeSpan = TimeSpan.FromHours(4);

    public AuthenticationController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost("token")]
    public IActionResult GenerateToken([FromBody] RegisterRequestDto request)
    {
        var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")!);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, request.Email),
                new Claim(JwtRegisteredClaimNames.Email, request.Email),
            }),
            Expires = DateTime.UtcNow.Add(TokenLifeSpan),
            Issuer = _configuration["JwtSettings:Issuer"],
            Audience = _configuration["JwtSettings:Audience"],
            SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        var stringToken = tokenHandler.WriteToken(token);

        return Ok(stringToken);
    }

    [Authorize]
    [HttpGet]
    public IActionResult Test()
    {
        return Ok("Valid jwt token");
    }
}