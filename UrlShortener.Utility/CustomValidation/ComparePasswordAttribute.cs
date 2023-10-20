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
        private readonly string _password;
        public ComparePasswordAttribute(string password) 
        {
            _password = password;
        }
        public override bool IsValid(object? value)
        {
            string? matchingPassword = (value as User)?.Password;
            return _password == matchingPassword;
        }
    }
}
