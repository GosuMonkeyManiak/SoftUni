namespace SharedTrip.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    using static Data.Common.DataConstrains.TripValidations;

    public class TripFormModel
    {
        [Required]
        public string StartPoint { get; init; }

        [Required]
        public string EndPoint { get; init; }

        [Required]
        public string DepartureTime { get; init; }
        
        public string ImagePath { get; init; }

        [Range(
            SeatsMinLength, 
            SeatsMaxLength,
            ErrorMessage = "Seat number must be between {1} {2}.")]
        public int Seats { get; init; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; init; }
    }
}
