namespace PetStore.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserToy
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(Toy))]
        public int ToyId { get; set; }
        public virtual Toy Toy { get; set; }
    }
}
