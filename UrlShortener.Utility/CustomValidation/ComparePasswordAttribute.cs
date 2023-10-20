using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Utility.CustomValidation
{
    public class ComparePasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            RegisterViewModel? instance = validationContext.ObjectInstance as RegisterViewModel;
            if (instance?.User.Password != value as string) 
            {
                return new ValidationResult("Confirm password don`t match!");
            }
            return ValidationResult.Success;
        }
    }
}
