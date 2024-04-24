using FluentResults;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class ActorService : IActorService
{
    private readonly AppDbContext _appDbContext;

    public ActorService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
    }

    public IEnumerable<Actor> GetAllActors()
    {
        return _appDbContext.Actors.ToList();
    }

    public Result<Actor> GetActorById(int id)
    {
        var actor = _appDbContext.Actors.FirstOrDefault(a => a.Id == id);

        if (actor == null)
        {
            return Result.Fail($"Actor with id {id} not found");
        }

        return Result.Ok(actor);
    }

    public Result DeleteActor(int id)
    {
        var actor = _appDbContext.Actors.FirstOrDefault(a => a.Id == id);

        if (actor == null)
        {
            return Result.Fail($"Actor with id {id} not found");
        }
        
        _appDbContext.Actors.Remove(actor);
        _appDbContext.SaveChanges();
        return Result.Ok();
    }

    public Result UpdateActor(int id, Actor updatedActor)
    {
        var actor = _appDbContext.Actors.FirstOrDefault(a => a.Id == id);
        if (actor == null)
        {
            return Result.Fail($"Actor with id {id} not found");
        }

        var existingActor = actor;
        existingActor.FirstName = updatedActor.FirstName;
        existingActor.LastName = updatedActor.LastName;
        existingActor.BirthDate = updatedActor.BirthDate;
        existingActor.Biography = updatedActor.Biography;
        existingActor.ProfilePictureUrl = updatedActor.ProfilePictureUrl;

        _appDbContext.Actors.Update(existingActor);
        _appDbContext.SaveChanges();
        return Result.Ok();
    }

    public Actor SaveActor(Actor actor)
    {
        _appDbContext.Actors.Add(actor);
        _appDbContext.SaveChanges();
        return actor;
    }
}