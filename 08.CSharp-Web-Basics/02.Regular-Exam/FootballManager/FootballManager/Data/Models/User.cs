namespace FootballManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Common.DataConstraints;
    using static Common.DataConstraints.UserConstraints;
    public class User
    {
        [Key]
        [MaxLength(DefaultIdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string UserName { get; init; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }

        public ICollection<UserPlayer> UserPlayers { get; init; } = new HashSet<UserPlayer>();
    }
}
