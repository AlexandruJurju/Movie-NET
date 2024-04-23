using FluentResults;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;

    public AuthenticationService(IUserService userService, IJwtService jwtService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _jwtService = jwtService;
    }


    public Result<User> RegisterUser(RegisterRequestDto registerRequest)
    {
        var findByUsernameResult = _userService.FindUserByUsername(registerRequest.Username);
        if (!findByUsernameResult.IsFailed)
        {
            return findByUsernameResult.ToResult();
        }

        var findByEmailResult = _userService.FindUserByEmail(registerRequest.Email);
        if (!findByEmailResult.IsFailed)
        {
            return findByEmailResult.ToResult();
        }

        var user = new User
        {
            Username = registerRequest.Username,
            Email = registerRequest.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password)
        };

        return _userService.SaveUser(user);
    }

    public Result<string> LoginUser(LoginRequestDto loginRequest)
    {
        var userResult = _userService.FindUserByEmail(loginRequest.Email);
        if (userResult.IsFailed)
        {
            return userResult.ToResult();
        }

        if (BCrypt.Net.BCrypt.HashPassword(loginRequest.Email) != userResult.Value.Password)
        {
            return Result.Fail("Wrong password used");
        }

        return _jwtService.GenerateToken(loginRequest);
    }
}