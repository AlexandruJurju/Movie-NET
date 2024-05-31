using FluentResults;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IPasswordCodeService
{
    Task<Result<User>> ForgotPasswordRequestAsync(ForgotPasswordDto forgotPasswordDto);
    Task DeleteCodeAsync(User user);
    Result<bool> CodesMatch(User user, string code);
}