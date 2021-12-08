namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Constants;

    public class Toy
    {
        public Toy()
        {
            UsersToys = new HashSet<UserToy>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.Toy_Name_Max_Length)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [ForeignKey(nameof(PetType))]
        public int PetTypeId { get; set; }
        public virtual PetType PetType { get; set; }

        [ForeignKey(nameof(ToyDistributor))]
        public int ToyDistributorId { get; set; }
        public virtual ToyDistributor ToyDistributor { get; set; }

        public long Amount { get; set; }

        public virtual ICollection<UserToy> UsersToys { get; set; }
    }
}
