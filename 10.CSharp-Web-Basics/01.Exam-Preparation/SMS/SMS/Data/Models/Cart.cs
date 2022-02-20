namespace SMS.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Common.DataConstraints;

    public class Cart
    {
        [Key]
        [MaxLength(DefaultIdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();
        
        public User User { get; init; }

        public ICollection<Product> Products { get; init; } = new HashSet<Product>();
    }
}
