﻿using System;
using System.Collections.Generic;

namespace Movie_Net_Backend.Migrations;

public partial class Genre
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
