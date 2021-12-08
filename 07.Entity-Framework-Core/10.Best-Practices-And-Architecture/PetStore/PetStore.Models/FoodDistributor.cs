namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class FoodDistributor
    {
        public FoodDistributor()
        {
            Foods = new HashSet<Food>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.Distributor_Name_Max_Length)]
        public string Name { get; set; }

        public decimal PriceByKg { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}
