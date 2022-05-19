namespace SharedTrip.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Common.DataConstrains;
    using static Common.DataConstrains.TripValidations;

    public class Trip
    {
        [Key] 
        [MaxLength(DefaultIdMaxLength)] 
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string StartPoint { get; init; }

        [Required]
        public string EndPoint { get; init; }

        public DateTime DepartureTime { get; init; }

        [MaxLength(SeatsMaxLength)]
        public int Seats { get; init; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; init; }

        public string ImagePath { get; init; }
        
        public ICollection<UserTrip> UserTrips { get; init; }
    }
}
