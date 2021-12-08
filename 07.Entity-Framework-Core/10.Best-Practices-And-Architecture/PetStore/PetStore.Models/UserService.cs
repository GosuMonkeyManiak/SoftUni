namespace PetStore.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserService
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}
