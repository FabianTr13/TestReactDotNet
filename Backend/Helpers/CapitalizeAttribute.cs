using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FabiApi.Helpers
{
    public class CapitalizeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult("Vacios");

            string firtLetter = value.ToString().Substring(0, 1);
            if (firtLetter != firtLetter.ToUpper())
                return new ValidationResult("Primera letra debe ser mayuscula");

            return ValidationResult.Success;
        }
    }
}