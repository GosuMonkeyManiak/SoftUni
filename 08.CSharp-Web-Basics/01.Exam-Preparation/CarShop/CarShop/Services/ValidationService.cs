namespace CarShop.Services
{
    using Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ValidationService : IValidationService
    {
        public (bool, IEnumerable<string>) IsModelValid(object model)
        {
            var context = new ValidationContext(model);
            var errors = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, errors, true);

            if (isValid)
            {
                return (isValid, null);
            }

            return (isValid, errors.Select(e => e.ErrorMessage));
        }

        public bool IsUserTypeValid(string userType)
        {
            if (userType.ToLower() != "client" &&
                userType.ToLower() != "mechanic")
            {
                return false;
            }

            return true;
        }
    }
}
