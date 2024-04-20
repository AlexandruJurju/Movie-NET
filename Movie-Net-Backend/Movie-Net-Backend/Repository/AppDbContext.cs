using Microsoft.EntityFrameworkCore;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Repository;

public class AppDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}