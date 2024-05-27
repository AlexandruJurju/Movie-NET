using FluentResults;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;
    private readonly IPasswordCodeService _passwordCodeService;

    public AuthenticationService(IUserService userService, IJwtService jwtService, IPasswordCodeService passwordCodeService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _jwtService = jwtService;
        _passwordCodeService = passwordCodeService;
    }

    public Result<User> RegisterUser(RegisterRequestDto registerRequest)
    {
        var findByUsernameResult = _userService.FindUserByUsername(registerRequest.Username);
        if (!findByUsernameResult.IsFailed) return Result.Fail("Username already exists");

        var findByEmailResult = _userService.FindUserByEmail(registerRequest.Email);
        if (!findByEmailResult.IsFailed) return Result.Fail("Email already exists");

        var user = new User
        {
            Username = registerRequest.Username,
            Email = registerRequest.Email,
            Role = Role.User,
            Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password)
        };

        // _emailService.Send(user.Email, "Register", "Registered to website");

        return _userService.SaveUser(user);
    }

    public Result<AuthenticationResponse> LoginUser(LoginRequestDto loginRequest)
    {
        var userResult = _userService.FindUserByEmail(loginRequest.Email);
        if (userResult.IsFailed) return userResult.ToResult();

        if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, userResult.Value.Password))
            return Result.Fail("Passwords dont match");

        return Result.Ok(new AuthenticationResponse
        {
            Token = _jwtService.GenerateToken(loginRequest),
            UserId = userResult.Value.Id
        });
    }

    public Result<User> ChangePassword(ResetPasswordDto changePasswordDto)
    {
        var userResult = _userService.FindUserById(changePasswordDto.UserId);
        if (userResult.IsFailed) return Result.Fail<User>("User not found");

        var matchResult = _passwordCodeService.CodesMatch(userResult.Value, changePasswordDto.Code);
        if (matchResult.IsFailed) return matchResult.ToResult();

        _passwordCodeService.DeleteCode(userResult.Value);
        userResult.Value.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword);

        return _userService.UpdateUser(changePasswordDto.UserId, userResult.Value);
    }
}