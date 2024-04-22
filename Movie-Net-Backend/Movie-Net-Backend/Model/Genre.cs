using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Movie_Net_Backend.Model;

[Table("genre")]
public class Genre
{
    [Required] [Key] [Column("id")] public int Id { get; set; }

    [Column("name")] [MaxLength(200)] public string Name { get; set; } = String.Empty;

    [JsonIgnore] public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}