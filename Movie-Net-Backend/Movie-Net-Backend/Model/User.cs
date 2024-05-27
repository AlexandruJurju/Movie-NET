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
    [Column("role")] public Role Role { get; set; }

    // todo: find a better way to store the default image
    [Column("profile_picture_url")] public string ProfilePictureUrl { get; set; } = "https://static-00.iconduck.com/assets.00/profile-default-icon-512x511-v4sw4m29.png";
    public virtual ICollection<Movie> Movies { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}