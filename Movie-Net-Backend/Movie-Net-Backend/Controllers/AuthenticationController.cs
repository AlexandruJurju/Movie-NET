using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[Route("api/v1/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;

    public AuthenticationController(IUserService userService, IJwtService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }


    [HttpPost("login")]
    public IActionResult LoginUser([FromBody] LoginRequestDto loginRequest)
    {
        var userResult = _userService.FindUserByEmail(loginRequest.Email);

        if (userResult.IsFailed)
        {
            return BadRequest(userResult.Errors);
        }

        return Ok(_jwtService.GenerateToken(loginRequest));
    }

    // TODO: hash password before saving
    [HttpPost("register")]
    public IActionResult RegisterUser([FromBody] RegisterRequestDto registerRequest)
    {
        var existingUsernameUser = _userService.FindUserByUsername(registerRequest.Username);

        if (!existingUsernameUser.IsFailed)
        {
            return BadRequest("Email already exists");
        }

        var existingEmailUser = _userService.FindUserByEmail(registerRequest.Email);

        if (!existingEmailUser.IsFailed)
        {
            return BadRequest("Email already exists");
        }

        var user = _userService.SaveUser(registerRequest);
        return CreatedAtAction(nameof(RegisterUser), new { id = user.Id }, user);
    }

    [Authorize]
    [HttpGet]
    public IActionResult Test()
    {
        return Ok("Valid jwt token");
    }
}