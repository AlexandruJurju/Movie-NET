using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController(IUserService userService, IMapper mapper) : ControllerBase
{
    private readonly IUserService _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<UserDto>))]
    public async Task<IActionResult> FindAllUsersAsync()
    {
        var users = _mapper.Map<List<UserDto>>(await _userService.FindAllUsersAsync());
        return Ok(users);
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(200, Type = typeof(UserDto))]
    public async Task<IActionResult> FindUserByIdAsync([FromRoute] int userId)
    {
        var result = await _userService.FindUserByIdAsync(userId);
        if (result.IsFailed) return BadRequest(result.Errors);

        var user = _mapper.Map<UserDto>(result.Value);

        return Ok(user);
    }

    [HttpDelete("{userId}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> DeleteUserByIdAsync([FromRoute] int userId)
    {
        var result = await _userService.DeleteUserByIdAsync(userId);
        if (result.IsFailed) return BadRequest(result.Errors);

        return Ok();
    }
}