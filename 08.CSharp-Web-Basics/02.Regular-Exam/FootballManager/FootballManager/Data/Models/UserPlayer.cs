namespace FootballManager.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.DataConstraints;

    public class UserPlayer
    {
        [Required]
        [ForeignKey(nameof(User))]
        [MaxLength(DefaultIdMaxLength)]
        public string UserId { get; init; }

        public User User { get; init; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }

        public Player Player { get; set; }
    }
}
