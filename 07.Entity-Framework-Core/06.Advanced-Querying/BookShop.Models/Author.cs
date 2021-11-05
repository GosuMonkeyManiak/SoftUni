using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    using System.Collections.Generic;

    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public int AuthorId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}