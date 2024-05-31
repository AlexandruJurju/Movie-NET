using FluentResults;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class AuthenticationService(IUserService userService, IJwtService jwtService, IPasswordCodeService passwordCodeService)
    : IAuthenticationService
{
    private readonly IUserService _userService = userService ?? throw new ArgumentNullException(nameof(userService));

    public async Task<Result<User>> RegisterUserAsync(RegisterRequestDto registerRequest)
    {
        var findByUsernameResult = await _userService.FindUserByUsernameAsync(registerRequest.Username);
        if (!findByUsernameResult.IsFailed) return Result.Fail("Username already exists");

        var findByEmailResult = await _userService.FindUserByEmailAsync(registerRequest.Email);
        if (!findByEmailResult.IsFailed) return Result.Fail("Email already exists");

        var user = new User
        {
            Username = registerRequest.Username,
            Email = registerRequest.Email,
            Role = Role.User,
            Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password)
        };

        // _emailService.Send(user.Email, "Register", "Registered to website");

        return await _userService.SaveUserAsync(user);
    }

    public async Task<Result<AuthenticationResponse>> LoginUserAsync(LoginRequestDto loginRequest)
    {
        var userResult = await _userService.FindUserByEmailAsync(loginRequest.Email);
        if (userResult.IsFailed) return userResult.ToResult();

        if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, userResult.Value.Password))
            return Result.Fail("Passwords dont match");

        return Result.Ok(new AuthenticationResponse
        {
            Token = await jwtService.GenerateToken(loginRequest),
            UserId = userResult.Value.Id
        });
    }

    public async Task<Result<User>> ChangePasswordAsync(ResetPasswordDto changePasswordDto)
    {
        var userResult = await _userService.FindUserByIdAsync(changePasswordDto.UserId);
        if (userResult.IsFailed) return Result.Fail<User>("User not found");

        var matchResult = passwordCodeService.CodesMatch(userResult.Value, changePasswordDto.Code);
        if (matchResult.IsFailed) return matchResult.ToResult();

        await passwordCodeService.DeleteCodeAsync(userResult.Value);
        userResult.Value.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword);

        return await _userService.UpdateUserAsync(changePasswordDto.UserId, userResult.Value);
    }
}