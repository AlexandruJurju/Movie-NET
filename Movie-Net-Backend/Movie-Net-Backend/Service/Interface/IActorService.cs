using FluentResults;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IActorService
{
    IEnumerable<Actor> GetAllActors();
    Result<Actor> GetActorById(int id);
    Result DeleteActor(int id);
    Result UpdateActor(int id, Actor updatedActor);
    Actor SaveActor(Actor actor);
}