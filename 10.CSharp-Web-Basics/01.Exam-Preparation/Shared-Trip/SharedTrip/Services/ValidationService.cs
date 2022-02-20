namespace SharedTrip.Services
{
    using System;
    using Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
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

        public bool IsDateTimeValid(string dateTime, string format)
        {
            var isValid = DateTime.TryParseExact(
                dateTime, 
                format, 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None,
                out DateTime result);

            return isValid;
        }
    }
}
