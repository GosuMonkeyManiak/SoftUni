namespace FootballManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Common.DataConstraints.PlayerConstraints;

    public class Player
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; init; }

        [Required]
        public string ImageUrl { get; init; }

        [Required]
        [MaxLength(PositionMaxLength)]
        public string Position { get; init; }
        
        public byte Speed { get; init; }

        public byte Endurance { get; init; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; init; }

        public ICollection<UserPlayer> UserPlayers { get; init; } = new HashSet<UserPlayer>();
    }
}
