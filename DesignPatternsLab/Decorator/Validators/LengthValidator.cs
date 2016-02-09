namespace _9.Decorator.Validators
{
    using System;
    using Interfaces;

    public class LengthValidator : IValidator
    {
        private readonly IValidator validator;
        private readonly int firstNumber;
        private readonly int secondNumber;

        public LengthValidator(int firstNumber, int secondNumber, IValidator validator)
        {
            this.validator = validator;
            this.firstNumber = firstNumber;
            this.secondNumber = secondNumber;
        }

        public bool Validate(string input)
        {
            if (input.Length < this.firstNumber || input.Length > this.secondNumber)
            {
                throw new ArgumentException("Incorrect length");
            }

            return this.validator.Validate(input);
        }
    }
}