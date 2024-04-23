using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

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
        var token = _authenticationService.LoginUser(loginRequest);
        
        return Ok(token);
    }

    [HttpPost("register")]
    public IActionResult RegisterUser([FromBody] RegisterRequestDto registerRequest)
    {
        var user = _authenticationService.RegisterUser(registerRequest);

        if (user.IsFailed)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(RegisterUser), new { id = user.Value.Id }, user.Value);
    }

    [Authorize]
    [HttpGet]
    public IActionResult Test()
    {
        return Ok("Valid jwt token");
    }
}