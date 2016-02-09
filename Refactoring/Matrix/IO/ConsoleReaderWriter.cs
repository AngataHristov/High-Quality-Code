namespace RotatingWalkInMatrix.IO
{
    using System;
    using System.Text;
    using Interfaces;

    public class ConsoleReaderWriter : IConsoleReaderWriter
    {
        private readonly StringBuilder outputBuffer;


        public ConsoleReaderWriter()
        {
            this.outputBuffer = new StringBuilder();
        }

        public bool AutoFlush { get; set; }

        public void Write(string line)
        {
            this.outputBuffer.AppendLine(line);

            if (this.AutoFlush)
            {
                this.Flush();
            }
        }

        public void Flush()
        {
            Console.Write(this.outputBuffer);
            this.outputBuffer.Clear();
        }

        public string ReadNextLine()
        {
            string inputArgs = Console.ReadLine();

            return inputArgs;
        }
    }
}
