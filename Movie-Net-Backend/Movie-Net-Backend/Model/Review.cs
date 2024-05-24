using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Net_Backend.Model;

// todo: make it so a user cant have more than 1 review for a movie
[Table("review")]
public class Review
{
    [Key, Column(Order = 0)]
    public int UserId { get; set; }

    [Key, Column(Order = 1)]
    public int MovieId { get; set; }

    [Column("review_text")]
    public string Text { get; set; }

    [Column("score")]
    public int Score { get; set; }

    public virtual Movie Movie { get; set; }
    public virtual User User { get; set; }
}