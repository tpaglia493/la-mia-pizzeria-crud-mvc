using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeria.Models.CustomValidationAttributes
{
    public class NoGifts: ValidationAttribute
        {

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                float fieldValue = (float)value;

                if (fieldValue == 0)
                {
                    return new ValidationResult("Non regaliamo pizze!!");
                }

                return ValidationResult.Success;
            }
        }
  
}
