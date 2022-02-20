namespace SharedTrip.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Common.DataConstrains;
    using static Common.DataConstrains.UserValidations;

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
        [MaxLength(PasswordMaxLength)]
        public string Password { get; init; }

        public ICollection<UserTrip> UserTrips { get; init; }
    }
}
