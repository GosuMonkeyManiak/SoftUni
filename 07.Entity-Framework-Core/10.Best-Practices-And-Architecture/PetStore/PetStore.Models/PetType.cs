namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class PetType
    {
        public PetType()
        {
            Breeds = new HashSet<Breed>();
            Foods = new HashSet<Food>();
            Toys = new HashSet<Toy>();
            Services = new HashSet<Service>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PetType_Name_Max_Length)]
        public string Name { get; set; }

        public virtual ICollection<Breed> Breeds { get; set; }

        public virtual ICollection<Food> Foods { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
