using FluentResults;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IPasswordCodeService
{
    Result<User> ForgotPasswordRequest(ForgotPasswordDto forgotPasswordDto);
    void DeleteCode(User user);
    Result<bool> CodesMatch(User user, string code);
}