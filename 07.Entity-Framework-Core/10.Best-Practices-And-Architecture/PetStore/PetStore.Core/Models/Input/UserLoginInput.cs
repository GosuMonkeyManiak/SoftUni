namespace PetStore.Core.Models.Input
{
    using System.ComponentModel.DataAnnotations;

    public class UserLoginInput
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}