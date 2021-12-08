namespace PetStore.Core.Utilities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public static class DtoValidator
    {
        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
