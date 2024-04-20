using Movie_Net_Backend.Exceptions;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Repository.Interfaces;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
    }

    public IEnumerable<Genre> GetAllGenres()
    {
        return _genreRepository.GetAllGenres();
    }

    public Genre GetGenreById(int id)
    {
        var genre = _genreRepository.GetGenreById(id);
        if (genre == null)
        {
            throw new GenreNotFoundException("Genre not found");
        }
        return genre;
    }

    public void DeleteGenre(int id)
    {
        var genre = GetGenreById(id);
        _genreRepository.DeleteGenre(genre);
    }

    public void UpdateGenre(int id, Genre updatedGenre)
    {
        var existingGenre = GetGenreById(id);
        existingGenre.Name = updatedGenre.Name;
        _genreRepository.UpdateGenre(existingGenre);
    }

    public void SaveGenre(Genre genre)
    {
        _genreRepository.SaveGenre(genre);
    }
}