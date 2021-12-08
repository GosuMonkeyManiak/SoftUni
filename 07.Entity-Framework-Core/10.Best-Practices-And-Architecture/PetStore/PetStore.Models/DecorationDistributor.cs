namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PetStore.Constants;

    public class DecorationDistributor
    {
        public DecorationDistributor()
        {
            Decorations = new HashSet<Decoration>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.Distributor_Name_Max_Length)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Decoration> Decorations { get; set; }
    }
}
