namespace SMS.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Common.DataConstraints.ProductConstrains;

    public class ProductFormModel
    {
        [Required]
        [StringLength(
            ProductNameMaxLength,
            MinimumLength = ProductNameMinLength,
            ErrorMessage = "Product name has to be between {2} and {1} characters.")]
        public string Name { get; init; }

        [Range(typeof(decimal), "0.05", "1000")]
        public decimal Price { get; init; }
    }
}
