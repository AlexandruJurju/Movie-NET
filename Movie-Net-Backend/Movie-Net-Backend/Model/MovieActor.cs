using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Model;

public class MovieActor
{
    [Key] public int Id { get; set; }

    public int MovieId { get; set; }
    public int ActorId { get; set; }
    public virtual Movie Movie { get; set; }
    public virtual Actor Actor { get; set; }

    public string Role { get; set; }
    public int DisplayOrder { get; set; }
}