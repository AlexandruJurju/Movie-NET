using Microsoft.EntityFrameworkCore;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Data;

public class AppDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Genres)
            .WithMany(g => g.Movies)
            .UsingEntity(j => j.ToTable("movie_genre"));

        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Users)
            .WithMany(u => u.Movies)
            .UsingEntity(watchlist => watchlist.ToTable("watchlist"));
    }
}