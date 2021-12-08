namespace PetStore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PaymentLog
    {
        [Key]
        public int Id { get; set; }

        public DateTime PayOn { get; set; }

        [ForeignKey(nameof(PaymentType))]
        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        public decimal Price { get; set; }
    }
}
