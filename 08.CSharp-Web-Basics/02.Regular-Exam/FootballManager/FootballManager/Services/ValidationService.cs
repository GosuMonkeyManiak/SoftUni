namespace FootballManager.Services
{
    using Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ValidationService : IValidationService
    {
        private static HashSet<string> allPositions = new()
        {
            "goalkeeper",
            "right fullback",
            "left fullback",
            "center back",
            "defender",
            "striker",
            "winger"
        };

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

        public bool IsPositionValid(string position)
        {
            if (!allPositions.Contains(position.ToLower()))
            {
                return false;
            }

            return true;
        }
    }
}
