using FluentResults;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IActorService
{
    Task<IEnumerable<Actor>> GetAllActorsAsync();
    Task<Result<Actor>> GetActorByIdAsync(int id);
    Task<Result> DeleteActorAsync(int id);
    Task<Result> UpdateActorAsync(int id, Actor updatedActor);
    Task<Actor> SaveActorAsync(Actor actor);
}