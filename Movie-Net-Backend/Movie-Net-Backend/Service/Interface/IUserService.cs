using FluentResults;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IUserService
{
    Result<User> FindUserByUsername(string username);
    Result<User> FindUserByEmail(string email);
    User SaveUser(RegisterRequestDto registerRequest);
}