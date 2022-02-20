namespace FootballManager.ViewModels.Players
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Common.DataConstraints.PlayerConstraints;

    public class PlayerFormModel
    {
        [Required]
        [StringLength(
            FullNameMaxLength,
            MinimumLength = FullNameMinLength,
            ErrorMessage = "Full Name must to be between {2} and {1} characters.")]
        public string FullName { get; init; }

        [Required]
        [Url]
        public string ImageUrl { get; init; }

        [Required]
        [StringLength(
            PositionMaxLength,
            MinimumLength = PositionMinLength,
            ErrorMessage = "Position must to be between {2} and {1} characters.")]
        public string Position { get; init; }
        
        [Range(
            typeof(long),
            "0", "10",
            ErrorMessage = "Speed must to be between {1} and {2}")]
        public long Speed { get; init; }
        
        [Range(
            typeof(long),
            "0", "10",
            ErrorMessage = "Endurance must to be between {1} and {2}")]
        public long Endurance { get; init; }

        [Required]
        [MaxLength(
            DescriptionMaxLength,
            ErrorMessage = "Description does not be more than {1}.")]
        public string Description { get; init; }
    }
}
