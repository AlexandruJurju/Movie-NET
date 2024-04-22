using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ActorController : ControllerBase
{
    private readonly IActorService _actorService;

    public ActorController(IActorService actorService)
    {
        _actorService = actorService ?? throw new ArgumentNullException(nameof(actorService));
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Actor>))]
    public IActionResult FindAllActors()
    {
        var actorsResult = _actorService.GetAllActors();
        return Ok(actorsResult);
    }

    [HttpGet("{actorId}")]
    [ProducesResponseType(200, Type = typeof(Actor))]
    [ProducesResponseType(400)]
    public IActionResult FindActorById([FromRoute] int actorId)
    {
        var actorResult = _actorService.GetActorById(actorId);
        if (actorResult.IsFailed)
        {
            return NotFound();
        }

        return Ok(actorResult.Value);
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Actor))]
    public IActionResult SaveActor([FromBody] Actor actor)
    {
        var createdActorResult = _actorService.SaveActor(actor);
        if (createdActorResult.IsFailed)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(SaveActor), new { id = createdActorResult.Value.Id }, createdActorResult.Value);
    }

    [HttpDelete("{actorId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult DeleteActor([FromRoute] int actorId)
    {
        var deleteResult = _actorService.DeleteActor(actorId);
        if (deleteResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPut("{actorId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult UpdateActor([FromRoute] int actorId, [FromBody] Actor updatedActor)
    {
        var updateResult = _actorService.UpdateActor(actorId, updatedActor);
        if (updateResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }
}