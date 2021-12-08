namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class ServiceType
    {
        public ServiceType()
        {
            Services = new HashSet<Service>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ServiceType_Name_Max_Length)]
        public string Name { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
