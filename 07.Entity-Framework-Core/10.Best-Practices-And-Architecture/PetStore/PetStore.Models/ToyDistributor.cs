namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class ToyDistributor
    {
        public ToyDistributor()
        {
            Toys = new HashSet<Toy>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.Distributor_Name_Max_Length)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }
    }
}
