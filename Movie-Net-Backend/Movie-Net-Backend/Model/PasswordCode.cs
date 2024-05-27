using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Model;

public class PasswordCode
{
    [Key] public int Id { get; set; }
    public string Code { get; set; }
    public int UserId { get; set; }

    public virtual User User { get; set; }
}