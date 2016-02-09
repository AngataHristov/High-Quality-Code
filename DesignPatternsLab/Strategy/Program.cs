namespace SharpCompiler
{
    using System.IO;
    using Strategy.Interfaces;
    using Strategy.ValidationStrategies;
    using System.Net;

    public class Program
    {
        private const string ProgramPath = "../../CSharpProgram.cs";
        private const string EntryClassName = "Strategy.Program";

        static void Main()
        {
            string code = File.ReadAllText(ProgramPath);
            ICodeSyntaxValidationStrategy codeValidationStrategy = new CodeLengthValidator();
            // codeValidationStrategy = new SystemNetValidator();
            var compiler = new CSharpCompiler(codeValidationStrategy);
            compiler.Compile(code);
            compiler.Execute(EntryClassName);

        }
    }
}
