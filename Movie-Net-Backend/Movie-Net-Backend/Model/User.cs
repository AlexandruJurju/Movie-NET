using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Net_Backend.Model;

[Table("user")]
public class User
{
    [Key] [Column("id")] public int Id { get; set; }
    [Column("email")] public string Email { get; set; }
    [Column("username")] public string Username { get; set; }
    [Column("password")] public string Password { get; set; }
    [Column("profile_picture_url")] public string ProfilePictureUrl { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
}