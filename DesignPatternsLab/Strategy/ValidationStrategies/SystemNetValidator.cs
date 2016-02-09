namespace Strategy.ValidationStrategies
{
    using Interfaces;
    using SharpCompiler.Exceptions;

    public class SystemNetValidator : ICodeValidationStrategy
    {
        public void Validate(string codeString)
        {
            if (!codeString.Contains("using System.Net"))
            {
                throw new CompilationException("Invalid input");
            }
        }
    }
}
