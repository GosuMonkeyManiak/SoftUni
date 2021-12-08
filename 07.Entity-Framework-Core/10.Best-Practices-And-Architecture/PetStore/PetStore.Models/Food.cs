namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Constants;

    public class Food
    {
        public Food()
        {
            UsersFoods = new HashSet<UserFood>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.Food_Name_Max_Length)]
        public string Name { get; set; }

        public decimal PriceByKg { get; set; }

        [ForeignKey(nameof(PetType))]
        public int PetTypeId { get; set; }
        public virtual PetType PetType { get; set; }

        [ForeignKey(nameof(FoodDistributor))]
        public int FoodDistributorId { get; set; }
        public virtual FoodDistributor FoodDistributor { get; set; }

        public decimal KgHave { get; set; }

        public virtual ICollection<UserFood> UsersFoods { get; set; }
    }
}
