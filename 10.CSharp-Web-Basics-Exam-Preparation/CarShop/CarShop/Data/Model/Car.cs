namespace CarShop.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.DataConstraints;
    using static Common.DataConstraints.CarConstraints;

    public class Car
    {
        [Key]
        [MaxLength(DefaultIdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; init; }

        public int Year { get; init; }

        [Required]
        public string PictureUrl { get; init; }

        [Required]
        [MaxLength(PlateNumberMaxLength)]
        public string PlateNumber { get; init; }

        [Required]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; init; }

        public User Owner { get; init; }

        public ICollection<Issue> Issues { get; init; } = new HashSet<Issue>();
    }
}
