namespace SMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.DataConstraints;
    using static Common.DataConstraints.ProductConstrains;

    public class Product
    {
        [Key]
        [MaxLength(DefaultIdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; init; }

        public decimal Price { get; init; }
        
        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }

        public Cart Cart { get; init; }
    }
}
