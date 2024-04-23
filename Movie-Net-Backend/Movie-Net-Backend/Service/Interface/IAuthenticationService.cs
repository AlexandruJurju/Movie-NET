﻿using FluentResults;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IAuthenticationService
{
    Result<User> RegisterUser(RegisterRequestDto registerRequest);
    Result<string> LoginUser(LoginRequestDto loginRequest);
}