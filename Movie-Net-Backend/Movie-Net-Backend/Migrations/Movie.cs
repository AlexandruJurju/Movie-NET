using System;
using System.Collections.Generic;

namespace Movie_Net_Backend.Migrations;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Headline { get; set; } = null!;

    public string Overview { get; set; } = null!;

    public DateOnly ReleaseDate { get; set; }

    public string PosterUrl { get; set; } = null!;

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
