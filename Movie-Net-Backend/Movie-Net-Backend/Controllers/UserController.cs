using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
    public IActionResult FindAllUsers()
    {
        var users = _userService.FindAllUsers();
        return Ok(users);
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(200, Type = typeof(User))]
    [ProducesResponseType(400)]
    public IActionResult FindUserById([FromRoute] int userId)
    {
        var result = _userService.FindUserById(userId);

        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result.Errors);
    }

    [HttpDelete("{userId}")]
    public IActionResult DeleteUserById([FromRoute] int userId)
    {
        var result = _userService.DeleteUserById(userId);

        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        return Ok();
    }
}