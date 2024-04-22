using Microsoft.EntityFrameworkCore;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Data;

public class AppDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}