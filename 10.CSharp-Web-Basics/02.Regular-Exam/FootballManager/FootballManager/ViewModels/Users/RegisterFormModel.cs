namespace FootballManager.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Common.DataConstraints.UserConstraints;

    public class RegisterFormModel
    {
        [Required]
        [StringLength(
            UsernameMaxLength,
            MinimumLength = UsernameMinLength,
            ErrorMessage = "Username must to be between {2} and {1} characters.")]
        public string Username { get; init; }

        [Required]
        [StringLength(
            EmailMaxLength,
            MinimumLength = EmailMinLength,
            ErrorMessage = "Email must to be between {2} and {1} characters.")]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        [StringLength(
            PasswordMaxLength,
            MinimumLength = PasswordMinLength,
            ErrorMessage = "Password must to be between {2} and {1} characters.")]
        public string Password { get; init; }

        [Compare(
            nameof(Password),
            ErrorMessage = "Confirm Password and Password does not match.")]
        public string ConfirmPassword { get; init; }
    }
}
