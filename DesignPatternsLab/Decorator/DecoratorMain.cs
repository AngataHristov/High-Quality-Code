namespace _9.Decorator
{
    using System;
    using Validators;

    public class DecoratorMain
    {
        public static void Main()
        {
            var validator = new AlphanumericValidator(
                new LengthValidator(0, 10,
                    new SimpleValidator()));

            Console.WriteLine(validator.Validate("a"));
        }
    }
}
