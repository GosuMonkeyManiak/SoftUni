namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class Gender
    {
        public Gender()
        {
            Pets = new HashSet<Pet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.Gender_Name_Max_Length)]
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
