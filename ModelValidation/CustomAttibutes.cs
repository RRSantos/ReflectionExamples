using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ModelValidation
{

    interface IValidationAttribute
    {
        IReadOnlyCollection<string> GetValidationErrors(object valueToValidate);
    }


    [AttributeUsage(AttributeTargets.Property)]
    class StringValidatorAttribute : Attribute, IValidationAttribute
    {
        public string RegexPattern { get; private set; }
        public int MinLength { get; private set; }
        public int MaxLength { get; private set; }


        public StringValidatorAttribute(string RegexPattern = "", int MinLength = -1, int MaxLength = -1)
        {
            this.RegexPattern = RegexPattern;
            this.MinLength = MinLength;
            this.MaxLength = MaxLength;
        }

        public IReadOnlyCollection<string> GetValidationErrors(object valueToValidate)
        {
            string finalValue = (string)valueToValidate;
            List<string> errors = new List<string>();
            if (!string.IsNullOrEmpty(RegexPattern))
            {
                Regex regexp = new Regex(RegexPattern);
                if (!regexp.IsMatch(finalValue))
                {
                    errors.Add($"Value '{finalValue}' is invalid. A valid value must be compliant with regular expression '{RegexPattern}' .");
                }
            }

            if (MinLength > -1)
            {
                if (String.IsNullOrEmpty(finalValue) || finalValue.Length < MinLength)
                {

                    errors.Add($"Size of '{finalValue}' is invalid. MinLength expected is {MinLength}.");
                }
            }

            if (MaxLength > -1)
            {
                if (String.IsNullOrEmpty(finalValue) || finalValue.Length > MaxLength)
                {

                    errors.Add($"Size of '{finalValue}' is invalid. MaxLength expected is {MaxLength}.");
                }
            }
            return errors;

        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    class IntegerValidatorAttibute : Attribute, IValidationAttribute
    {

        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }

        public IntegerValidatorAttibute(int MinValue = int.MinValue, int MaxValue = int.MaxValue)
        {
            this.MinValue = MinValue;
            this.MaxValue = MaxValue;
        }

        public IReadOnlyCollection<string> GetValidationErrors(object valueToValidate)
        {
            int finalValue = (int)valueToValidate;

            List<string> errors = new List<string>();
            if (finalValue < MinValue)
            {
                errors.Add($"Value '{finalValue}' is invalid. MinValue permitted is {MinValue}");
            }
            if (finalValue > MaxValue)
            {
                errors.Add($"Value '{finalValue}' is invalid. MaxValue permitted is {MaxValue}");
            }

            return errors;
        }
    }
}
