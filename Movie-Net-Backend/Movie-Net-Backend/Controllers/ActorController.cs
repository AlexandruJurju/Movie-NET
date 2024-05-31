using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ActorController(IActorService actorService, IMapper mapper) : ControllerBase
{
    private readonly IActorService _actorService = actorService ?? throw new ArgumentNullException(nameof(actorService));

    [HttpGet]
    public async Task<IActionResult> FindAllActorsAsync()
    {
        var actors = mapper.Map<List<ActorDto>>(await _actorService.GetAllActorsAsync());
        return Ok(actors);
    }

    [HttpGet("{actorId}")]
    public async Task<IActionResult> FindActorByIdAsync([FromRoute] int actorId)
    {
        var actorResult = await _actorService.GetActorByIdAsync(actorId);
        if (actorResult.IsFailed) return NotFound();

        var actor = mapper.Map<ActorDto>(actorResult.Value);

        return Ok(actor);
    }

    [HttpPost]
    public async Task<IActionResult> SaveActorAsync([FromBody] ActorDto actorDto)
    {
        var actor = mapper.Map<Actor>(actorDto);
        var actorCreated = await _actorService.SaveActorAsync(actor);
        return CreatedAtAction(nameof(SaveActorAsync), new { actorId = actorCreated.Id }, actorDto);
    }

    [HttpDelete("{actorId}")]
    public async Task<IActionResult> DeleteActorAsync([FromRoute] int actorId)
    {
        var deleteResult = await _actorService.DeleteActorAsync(actorId);
        if (deleteResult.IsFailed) return NotFound();

        return Ok();
    }

    [HttpPut("{actorId}")]
    public async Task<IActionResult> UpdateActorAsync([FromRoute] int actorId, [FromBody] ActorDto updatedActor)
    {
        if (actorId != updatedActor.Id) return BadRequest();

        var actor = mapper.Map<Actor>(updatedActor);

        var updateResult = await _actorService.UpdateActorAsync(actorId, actor);
        if (updateResult.IsFailed) return NotFound();

        return Ok();
    }
}