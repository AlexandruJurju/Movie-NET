using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Net_Backend.Model;

[Table("movie")]
public class Movie
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Required]
    [Column("title")]
    public string Title { get; set; }
    
    [Required]
    [Column("headline")]
    public string Headline { get; set; }
    
    [Required]
    [Column("overview")]
    public string Overview { get; set; }
    
    [Column("release_date")]
    public DateOnly ReleaseDate { get; set; }

    public ICollection<Genre> Genres { get; set; }
}