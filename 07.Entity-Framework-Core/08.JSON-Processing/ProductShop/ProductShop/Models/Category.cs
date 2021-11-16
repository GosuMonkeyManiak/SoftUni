using System.ComponentModel.DataAnnotations;

namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.CategoryProducts = new List<CategoryProduct>();
        }

        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
