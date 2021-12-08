namespace PetStore.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserDecoration
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(Decoration))]
        public int DecorationId { get; set; }
        public virtual Decoration Decoration { get; set; }
    }
}
