namespace SMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.DataConstraints;
    using static Common.DataConstraints.UserConstrains;

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

        [Required]
        [ForeignKey(nameof(Cart))]
        [MaxLength(DefaultIdMaxLength)]
        public string CartId { get; init; }

        public Cart Cart { get; init; }
    }
}
