namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using PetStore.Constants;

    public class Decoration
    {
        public Decoration()
        {
            UsersDecorations = new HashSet<UserDecoration>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.Decoration_Name_Max_Length)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [ForeignKey(nameof(DecorationDistributor))]
        public int DecorationDistributorId { get; set; }
        public virtual DecorationDistributor DecorationDistributor { get; set; }

        public long Amount { get; set; }

        public virtual ICollection<UserDecoration> UsersDecorations { get; set; }
    }
}
