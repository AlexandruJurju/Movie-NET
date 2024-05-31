using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthenticationController(IAuthenticationService authenticationService, IMapper mapper, IPasswordCodeService passwordCodeService)
    : ControllerBase
{
    private readonly IAuthenticationService _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    private readonly IPasswordCodeService _passwordCodeService = passwordCodeService ?? throw new ArgumentNullException(nameof(passwordCodeService));

    [HttpPost("login")]
    [ProducesResponseType(200, Type = typeof(AuthenticationResponse))]
    public async Task<IActionResult> LoginUserAsync([FromBody] LoginRequestDto loginRequest)
    {
        var loginResult = await _authenticationService.LoginUserAsync(loginRequest);

        if (loginResult.IsFailed) return BadRequest(loginResult.Reasons);

        return Ok(loginResult.Value);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterRequestDto registerRequest)
    {
        var registerResult = await _authenticationService.RegisterUserAsync(registerRequest);

        if (registerResult.IsFailed) return BadRequest(registerResult.ToResult());

        return CreatedAtAction(nameof(RegisterUserAsync), new { id = registerResult.Value.Id }, registerResult.Value);
    }

    [HttpPost("forgot-password")]
    [ProducesResponseType(200, Type = typeof(UserDto))]
    public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordDto forgotPasswordDto)
    {
        var result = await _passwordCodeService.ForgotPasswordRequestAsync(forgotPasswordDto);
        if (result.IsFailed) return BadRequest(result.Errors);

        var user = _mapper.Map<UserDto>(result.Value);

        return Ok(user);
    }

    [HttpPost("change-password")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> ChangePasswordAsync([FromBody] ResetPasswordDto changePasswordDto)
    {
        var result = await _authenticationService.ChangePasswordAsync(changePasswordDto);
        if (result.IsFailed) return BadRequest(result.Errors);

        return Ok();
    }

    [HttpGet]
    public IActionResult Test()
    {
        return Ok("Valid jwt token");
    }
}