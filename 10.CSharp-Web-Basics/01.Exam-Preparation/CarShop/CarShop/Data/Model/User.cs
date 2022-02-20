namespace CarShop.Data.Model
{
    using System;
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
        public string Username { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        [MaxLength(HashedPasswordMaxLength)]
        public string Password { get; init; }

        public bool IsMechanic { get; init; }
    }
}
