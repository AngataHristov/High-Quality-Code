namespace BangaloreUniversityLearningSystem
{
    using Core;
    using Core.IO;
    using Data;
    using Interfaces;

    public class UniversityMain
    {
        public static void Main()
        {
            IBangaloreUniversityData data = new BangaloreUniversityData();

            IInputReader reader = new ConsoleReader();

            IOutputWriter writer = new ConsoleWriter
            {
                AutoFlush = true
            };

            IEngine engine = new BangaloreUniversityEngine(reader, writer, data);
            engine.Run();
        }
    }
}