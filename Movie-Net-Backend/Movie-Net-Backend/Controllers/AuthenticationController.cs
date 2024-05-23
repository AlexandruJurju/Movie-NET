using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[AllowAnonymous]
[Route("api/v1/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public AuthenticationController(IAuthenticationService authenticationService, IMapper mapper)
    {
        _authenticationService = authenticationService;
        _mapper = mapper;
    }


    [HttpPost("login")]
    [ProducesResponseType(200, Type = typeof(AuthenticationResponse))]
    public IActionResult LoginUser([FromBody] LoginRequestDto loginRequest)
    {
        var loginResult = _authenticationService.LoginUser(loginRequest);

        if (loginResult.IsFailed) return BadRequest(loginResult.ToResult());

        return Ok(loginResult.Value);
    }

    [HttpPost("register")]
    public IActionResult RegisterUser([FromBody] RegisterRequestDto registerRequest)
    {
        var registerResult = _authenticationService.RegisterUser(registerRequest);

        if (registerResult.IsFailed) return BadRequest(registerResult.ToResult());

        return CreatedAtAction(nameof(RegisterUser), new { id = registerResult.Value.Id }, registerResult.Value);
    }

    [HttpPost("forgot-password")]
    [ProducesResponseType(200, Type = typeof(UserDto))]
    public IActionResult ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
    {
        var result = _authenticationService.ForgotPasswordRequest(forgotPasswordDto);

        if (result.IsFailed) return BadRequest(result.Errors);

        var user = _mapper.Map<UserDto>(result.Value);

        return Ok(user);
    }

    [Authorize]
    [HttpPost("change-password")]
    [ProducesResponseType(200)]
    public IActionResult ChangePassword([FromBody] ResetPasswordDto changePasswordDto)
    {
        var result = _authenticationService.ChangePassword(changePasswordDto);

        if (result.IsFailed) return BadRequest(result.Errors);

        return Ok();
    }

    [Authorize]
    [HttpGet]
    public IActionResult Test()
    {
        return Ok("Valid jwt token");
    }
}