using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Helper
{
    public static class ValidatorHelper
    {
        public static string? WrapErrors(ValidationResult validationResult)
        {
            if (validationResult.Errors.Count == 0)
                return null;

            return validationResult.Errors
                .Select(m => m.ErrorMessage)
                .Aggregate((acc, m) => $"{acc}\n• {m}");
        }
    }
}
