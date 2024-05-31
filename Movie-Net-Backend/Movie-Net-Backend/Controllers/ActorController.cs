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

    /// <summary>
    /// Retrieves all actors
    /// </summary>
    /// <response code="200">Successful response</response>
    [HttpGet]
    public async Task<IActionResult> FindAllActorsAsync()
    {
        var actors = mapper.Map<List<ActorDto>>(await _actorService.GetAllActorsAsync());
        return Ok(actors);
    }


    /// <summary>
    /// Retrieves an actor by ID
    /// </summary>
    /// <param name="actorId">The id of the actor to search</param>
    /// <returns>The ActorDto object corresponding to the provided ID</returns>
    /// <response code="200">Successful response</response>
    /// <response code="404">Actor not found</response>
    [HttpGet("{actorId}")]
    [ProducesResponseType(200, Type = typeof(ActorDto))]
    public async Task<IActionResult> FindActorByIdAsync([FromRoute] int actorId)
    {
        var actorResult = await _actorService.GetActorByIdAsync(actorId);
        if (actorResult.IsFailed) return NotFound();

        var actor = mapper.Map<ActorDto>(actorResult.Value);

        return Ok(actor);
    }

    /// <summary>
    /// Create a new actor
    /// </summary>
    /// <param name="actorDto">The actor to save</param>
    /// <response code="201">Actor created</response>
    [HttpPost]
    public async Task<IActionResult> SaveActorAsync([FromBody] ActorDto actorDto)
    {
        var actor = mapper.Map<Actor>(actorDto);
        var actorCreated = await _actorService.SaveActorAsync(actor);
        return CreatedAtAction(nameof(SaveActorAsync), new { actorId = actorCreated.Id }, actorDto);
    }


    /// <summary>
    /// Deletes an actor by ID
    /// </summary>
    /// <param name="actorId">The ID of the actor to delete</param>
    /// <returns>Success status</returns>
    /// <response code="200">Successful operation</response>
    /// <response code="404">Actor not found</response>
    [HttpDelete("{actorId}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> DeleteActorAsync([FromRoute] int actorId)
    {
        var deleteResult = await _actorService.DeleteActorAsync(actorId);
        if (deleteResult.IsFailed) return NotFound();

        return Ok();
    }

    /// <summary>
    /// Updates an actor
    /// </summary>
    /// <param name="actorId">The ID of the actor to update</param>
    /// <param name="updatedActor">The updated actor information</param>
    /// <returns>Success status</returns>
    /// <response code="200">Successful operation</response>
    /// <response code="404">Actor not found</response>
    [HttpPut("{actorId}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> UpdateActorAsync([FromRoute] int actorId, [FromBody] ActorDto updatedActor)
    {
        if (actorId != updatedActor.Id) return BadRequest();

        var actor = mapper.Map<Actor>(updatedActor);

        var updateResult = await _actorService.UpdateActorAsync(actorId, actor);
        if (updateResult.IsFailed) return NotFound();

        return Ok();
    }
}