using AutoMapper;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Movie, MovieDto>();
        CreateMap<Actor, ActorDto>();
        CreateMap<Genre, GenreDto>();
        CreateMap<User, UserDto>();
        CreateMap<MovieActor, MovieActorDto>();
    }
}