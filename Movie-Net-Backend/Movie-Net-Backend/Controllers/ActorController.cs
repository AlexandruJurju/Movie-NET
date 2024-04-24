using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ActorController : ControllerBase
{
    private readonly IActorService _actorService;
    private readonly IMapper _mapper;

    public ActorController(IActorService actorService, IMapper mapper)
    {
        _actorService = actorService ?? throw new ArgumentNullException(nameof(actorService));
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult FindAllActors()
    {
        var actors = _mapper.Map<List<ActorDto>>(_actorService.GetAllActors());
        return Ok(actors);
    }

    [HttpGet("{actorId}")]
    public IActionResult FindActorById([FromRoute] int actorId)
    {
        var actorResult = _actorService.GetActorById(actorId);
        if (actorResult.IsFailed)
        {
            return NotFound();
        }

        var actor = _mapper.Map<ActorDto>(actorResult.Value);

        return Ok(actor);
    }

    [HttpPost]
    public IActionResult SaveActor([FromBody] ActorDto actorDto)
    {
        var actor = _mapper.Map<Actor>(actorDto);
        var actorCreated = _actorService.SaveActor(actor);
        return CreatedAtAction(nameof(SaveActor), actorDto);
    }

    [HttpDelete("{actorId}")]
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
    public IActionResult UpdateActor([FromRoute] int actorId, [FromBody] ActorDto updatedActor)
    {
        if (actorId != updatedActor.Id)
        {
            return BadRequest();
        }

        var actor = _mapper.Map<Actor>(updatedActor);

        var updateResult = _actorService.UpdateActor(actorId, actor);
        if (updateResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }
}