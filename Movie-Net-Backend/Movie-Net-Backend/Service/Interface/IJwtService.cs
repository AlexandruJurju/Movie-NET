using Movie_Net_Backend.Dto;

namespace Movie_Net_Backend.Service.Interface;

public interface IJwtService
{
    string GenerateToken(LoginRequestDto loginRequest);
}