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

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    [HttpPost("login")]
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

    [Authorize]
    [HttpGet]
    public IActionResult Test()
    {
        return Ok("Valid jwt token");
    }
}