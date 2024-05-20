using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Net_Backend.Model;

[Table("genre")]
public class Genre
{
    [Key] [Column("id")] public int Id { get; set; }
    [Column("name")] public string Name { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
}