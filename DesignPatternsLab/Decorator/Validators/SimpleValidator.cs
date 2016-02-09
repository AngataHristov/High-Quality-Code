namespace _9.Decorator.Validators
{
    using Interfaces;

    public class SimpleValidator : IValidator
    {
        public bool Validate(string input)
        {
            return input != null;
        }
    }
}
