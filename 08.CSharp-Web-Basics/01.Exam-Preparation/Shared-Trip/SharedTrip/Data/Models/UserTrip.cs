namespace SharedTrip.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.DataConstrains;

    public class UserTrip
    {
        [Required]
        [MaxLength(DefaultIdMaxLength)]
        [ForeignKey(nameof(User))]
        public string UserId { get; init; }

        public User User { get; init; }

        [Required]
        [MaxLength(DefaultIdMaxLength)]
        [ForeignKey(nameof(Trip))]
        public string TripId { get; init; }

        public Trip Trip { get; init; }
    }
}
