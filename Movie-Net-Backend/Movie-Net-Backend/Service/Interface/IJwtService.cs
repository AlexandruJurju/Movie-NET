using FluentResults;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IJwtService
{
    string GenerateToken(LoginRequestDto loginRequest);
}