namespace Strategy.ValidationStrategies
{
    using System.CodeDom.Compiler;
    using System.Text;
    using Microsoft.CSharp;
    using SharpCompiler.Exceptions;
    using Strategy.Interfaces;
    using System.Net;

    public class CodeLengthValidator : ICodeSyntaxValidationStrategy
    {
        public void Validate(string codeString)
        {
            if (codeString.Length < 20)
            {
                throw new CompilationException("Invalid string length");
            }
        }
    }
}