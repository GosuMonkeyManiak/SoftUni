namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CustomerServiceType
    {
        public CustomerServiceType()
        {
            Transactions = new HashSet<IncomeLog>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<IncomeLog> Transactions { get; set; }
    }
}
