namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class User
    {
        public User()
        {
            Pets = new HashSet<Pet>();
            UsersFoods = new HashSet<UserFood>();
            UsersToys = new HashSet<UserToy>();
            UsersDecorations = new HashSet<UserDecoration>();
            UsersServices = new HashSet<UserService>();
            Transactions = new HashSet<IncomeLog>();
        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        
        [MaxLength(GlobalConstants.User_Phone_Max_Length)]
        public string Phone { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

        public virtual ICollection<UserFood> UsersFoods { get; set; }

        public virtual ICollection<UserToy> UsersToys { get; set; }

        public virtual ICollection<UserDecoration> UsersDecorations { get; set; }

        public virtual ICollection<UserService> UsersServices { get; set; }

        public virtual ICollection<IncomeLog> Transactions { get; set; }
    }
}
