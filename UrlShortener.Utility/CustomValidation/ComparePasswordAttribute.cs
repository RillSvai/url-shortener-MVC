using System.ComponentModel.DataAnnotations;
using UrlShortener.Models;

namespace UrlShortener.Utility.CustomValidation
{
    public class ComparePasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            RegisterViewModel? instance = validationContext.ObjectInstance as RegisterViewModel;
            if (instance?.User!.Password != value as string) 
            {
                return new ValidationResult("Confirm password don`t match!");
            }
            return ValidationResult.Success;
        }
    }
}
