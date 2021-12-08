namespace PetStore.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserFood
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(Food))]
        public int FoodId { get; set; }
        public virtual Food Food { get; set; }
    }
}
