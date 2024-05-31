using FluentResults;
using Microsoft.EntityFrameworkCore;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class ActorService(AppDbContext appDbContext) : IActorService
{
    private readonly AppDbContext _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));

    public async Task<IEnumerable<Actor>> GetAllActorsAsync()
    {
        return await _appDbContext.Actors.ToListAsync();
    }

    public async Task<Result<Actor>> GetActorByIdAsync(int id)
    {
        var actor = await _appDbContext.Actors.FirstOrDefaultAsync(a => a.Id == id);

        if (actor == null) return Result.Fail($"Actor with id {id} not found");

        return Result.Ok(actor);
    }

    public async Task<Result> DeleteActorAsync(int id)
    {
        var actor = await _appDbContext.Actors.FirstOrDefaultAsync(a => a.Id == id);

        if (actor == null) return Result.Fail($"Actor with id {id} not found");

        _appDbContext.Actors.Remove(actor);
        await _appDbContext.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> UpdateActorAsync(int id, Actor updatedActor)
    {
        var actor = await _appDbContext.Actors.FirstOrDefaultAsync(a => a.Id == id);
        if (actor == null) return Result.Fail($"Actor with id {id} not found");

        actor.FirstName = updatedActor.FirstName;
        actor.LastName = updatedActor.LastName;
        actor.BirthDate = updatedActor.BirthDate;
        actor.Biography = updatedActor.Biography;
        actor.ProfilePictureUrl = updatedActor.ProfilePictureUrl;

        _appDbContext.Actors.Update(actor);
        await _appDbContext.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Actor> SaveActorAsync(Actor actor)
    {
        await _appDbContext.Actors.AddAsync(actor);
        await _appDbContext.SaveChangesAsync();
        return actor;
    }
}