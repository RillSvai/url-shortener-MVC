using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Utility.CustomValidation
{
	public class UrlAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			Uri validatedUri;
			string? url = (value as Url)?.OriginalUrl;
			if (Uri.TryCreate(url, UriKind.Absolute, out validatedUri!))
			{
				if (validatedUri.Scheme == Uri.UriSchemeHttp || validatedUri.Scheme == Uri.UriSchemeHttps)
				{
					return ValidationResult.Success;
				}
			}
			return new ValidationResult("Url isn`t valid!");
		}
	}
}
