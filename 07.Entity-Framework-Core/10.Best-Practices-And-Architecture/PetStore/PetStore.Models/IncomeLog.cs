namespace PetStore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class IncomeLog
    {
        [Key]
        public int Id { get; set; }

        public DateTime CustomerPayOn { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(CustomerServiceType))]
        public int CustomerServiceTypeId { get; set; }
        public virtual CustomerServiceType CustomerServiceType { get; set; }

        public decimal PricePay { get; set; }
    }
}
