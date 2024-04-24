using AutoMapper;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Movie, MovieDto>();
        CreateMap<MovieDto, Movie>();
        CreateMap<Actor, ActorDto>();
        CreateMap<ActorDto, Actor>();
        CreateMap<Genre, GenreDto>();
        CreateMap<GenreDto, Genre>();
        CreateMap<User, UserDto>();
        CreateMap<MovieActor, MovieActorDto>();
    }
}