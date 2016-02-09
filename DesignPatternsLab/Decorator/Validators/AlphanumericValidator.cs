namespace _9.Decorator.Validators
{
    using System;
    using Interfaces;

    public class AlphanumericValidator : IValidator
    {
        private readonly IValidator validator;

        public AlphanumericValidator(IValidator validator)
        {
            this.validator = validator;
        }

        public bool Validate(string input)
        {
            foreach (var symbol in input)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    throw new ArgumentException("Invalid input contance.");
                }
            }

            return this.validator.Validate(input);
        }
    }
}