using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeria.Models.CustomValidationAttributes
{
    public class NoNegative : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            float fieldValue = (float)value;

            if (fieldValue < 0)
            {
                return new ValidationResult("Non puoi inserire un valore negativo!");
            }

            return ValidationResult.Success;
        }
    }
}
