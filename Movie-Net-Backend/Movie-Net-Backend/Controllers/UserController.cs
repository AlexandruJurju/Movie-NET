using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<UserDto>))]
    public IActionResult FindAllUsers()
    {
        var users = _mapper.Map<List<UserDto>>(_userService.FindAllUsers());
        return Ok(users);
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(200, Type = typeof(UserDto))]
    public IActionResult FindUserById([FromRoute] int userId)
    {
        var result = _userService.FindUserById(userId);
        if (result.IsFailed) return BadRequest(result.Errors);

        var user = _mapper.Map<UserDto>(result.Value);

        return Ok(user);
    }

    [HttpDelete("{userId}")]
    [ProducesResponseType(200)]
    public IActionResult DeleteUserById([FromRoute] int userId)
    {
        var result = _userService.DeleteUserById(userId);

        if (result.IsFailed) return BadRequest(result.Errors);

        return Ok();
    }
    
}