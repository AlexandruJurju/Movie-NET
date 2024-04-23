﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Movie_Net_Backend.Model;

public class MovieActor
{
    [Key] public int Id { get; set; }

    public int MovieId { get; set; }
    public int ActorId { get; set; }
    [JsonIgnore]
    public virtual Movie? Movie { get; set; }
    [JsonIgnore]
    public virtual Actor? Actor { get; set; }

    public string Role { get; set; }
    public int DisplayOrder { get; set; }
}