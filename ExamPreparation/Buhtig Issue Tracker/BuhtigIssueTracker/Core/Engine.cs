namespace BuhtigIssueTracker.Core
{
    using System;
    using Infrastructure;
    using Interfaces;

    public class Engine : IEngine
    {
        private readonly IDispatcher dispatcher;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public Engine(IDispatcher dispatcher, IInputReader reader, IOutputWriter writer)
        {
            this.dispatcher = dispatcher;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string inputUrl = this.reader.ReadNextLine();
                if (string.IsNullOrEmpty(inputUrl))
                {
                    break;
                }

                inputUrl = inputUrl.Trim();
                try
                {
                    var endpoint = new Endpoint(inputUrl);
                    string viewResult = this.dispatcher.DispatchAction(endpoint);
                    Console.WriteLine(viewResult);
                }
                catch (Exception ex)
                {
                    this.writer.Write(ex.Message);
                }
            }
        }
    }
}