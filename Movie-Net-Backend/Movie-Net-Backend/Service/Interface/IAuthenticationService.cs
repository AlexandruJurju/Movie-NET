using FluentResults;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IAuthenticationService
{
    Task<Result<User>> RegisterUserAsync(RegisterRequestDto registerRequest);
    Task<Result<AuthenticationResponse>> LoginUserAsync(LoginRequestDto loginRequest);
    Task<Result<User>> ChangePasswordAsync(ResetPasswordDto changePasswordDto);
}