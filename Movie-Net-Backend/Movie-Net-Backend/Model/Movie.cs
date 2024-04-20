using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Net_Backend.Model;

[Table("movie")]
public class Movie
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Headline { get; set; }
    public string Overview { get; set; }
}