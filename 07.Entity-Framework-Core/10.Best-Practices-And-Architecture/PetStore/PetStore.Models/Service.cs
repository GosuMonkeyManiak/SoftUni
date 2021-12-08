namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Service
    {
        public Service()
        {
            UsersServices = new HashSet<UserService>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(ServiceType))]
        public int ServiceTypeId { get; set; }
        public virtual ServiceType ServiceType { get; set; }

        [ForeignKey(nameof(PetType))]
        public int PetTypeId { get; set; }
        public virtual PetType PetType { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<UserService> UsersServices { get; set; }
    }
}
