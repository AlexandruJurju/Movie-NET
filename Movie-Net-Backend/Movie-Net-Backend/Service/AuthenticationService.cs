﻿using FluentResults;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;
    private readonly IEmailService _emailService;

    public AuthenticationService(IUserService userService, IJwtService jwtService, IEmailService emailService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _jwtService = jwtService;
        _emailService = emailService;
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
            Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password)
        };

        _emailService.Send(user.Email, "Register", "Registered to website");

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
            Token = _jwtService.GenerateToken(loginRequest)
        });
    }

    public void ResetPassword(PasswordResetDto passwordResetDto)
    {
        _emailService.Send(passwordResetDto.Email, "Password Reset", "RESET");
    }
}