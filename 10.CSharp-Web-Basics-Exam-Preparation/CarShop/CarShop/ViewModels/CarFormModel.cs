namespace CarShop.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Common.DataConstraints.CarConstraints;

    public class CarFormModel
    {
        [Required]
        [StringLength(
            ModelMaxLength,
            MinimumLength = ModelMinLength,
            ErrorMessage = "Model must to be between {2} and {1} characters.")]
        public string Model { get; init; }

        [Range(
            1900, 
            2050,
            ErrorMessage = "Year must to be between {2} and {1}.")]
        public int Year { get; init; }

        [Required]
        [Url]
        public string Image { get; init; }

        [Required]
        [RegularExpression(
            @"^[A-Za-z]{2}[0-9]{4}[A-Za-z]{2}$",
            ErrorMessage = "Plate number must be in format PB0011XT.")]
        public string PlateNumber { get; init; }
    }
}
