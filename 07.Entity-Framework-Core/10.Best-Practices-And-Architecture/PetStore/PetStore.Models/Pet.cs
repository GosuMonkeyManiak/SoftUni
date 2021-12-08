namespace PetStore.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Constants;

    public class Pet
    {
        [Key] 
        public string Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.Pet_Name_Max_Length)]
        public string Name { get; set; }

        [ForeignKey(nameof(Gender))]
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        [ForeignKey(nameof(Breed))]
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        public byte Age { get; set; }

        public decimal Price { get; set; }

        [ForeignKey(nameof(Buyer))]
        public string BuyerId { get; set; }
        public virtual User Buyer { get; set; }
    }
}
