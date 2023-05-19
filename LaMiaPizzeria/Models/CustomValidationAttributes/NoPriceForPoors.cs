using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeria.Models.CustomValidationAttributes
{
    public class NoPriceForPoors : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            float fieldValue = (float)value;

            if (fieldValue < 19)
            {
                return new ValidationResult("Non vendiamo pizze ai poveri!");
            }

            return ValidationResult.Success;
        }
    }



}
