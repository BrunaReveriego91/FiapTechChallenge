using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace FiapTechChallenge.API.Core.Helpers
{
    public static class Extensions
    {
        public static List<string> ToListString(this List<ValidationFailure> errors)
        {
            List<string> result = new();

            foreach (var error in errors)
            {
                result.Add(error.ErrorMessage);
            }
            return result;
        }

        public static string Concat(this List<ValidationFailure> errors, string concat)
        {
            List<string> result = new();

            foreach (var error in errors)
            {
                result.Add(error.ErrorMessage);
            }
            return string.Join(concat + Environment.NewLine, result.ToArray());
        }
    }
}