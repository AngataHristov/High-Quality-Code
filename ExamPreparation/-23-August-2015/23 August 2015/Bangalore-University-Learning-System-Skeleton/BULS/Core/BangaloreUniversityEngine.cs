namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Controllers;
    using Data;
    using Exceptions;
    using Interfaces;
    using Models;

    public class BangaloreUniversityEngine : IEngine
    {
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;
        private readonly IBangaloreUniversityData data;

        public BangaloreUniversityEngine(IInputReader reader, IOutputWriter writer, IBangaloreUniversityData data)
        {
            this.reader = reader;
            this.writer = writer;
            this.data = data;
        }

        public IInputReader Reader
        {
            get { return this.reader; }
        }

        public IOutputWriter Writer
        {
            get { return this.writer; }
        }

        public void Run()
        {
            User currentUser = null;

            while (true)
            {
                string inputLine = this.reader.ReadNextLine();
                if (inputLine == null)
                {
                    break;
                }

                var route = new Route(inputLine);
                var expectedController = route.ControllerName;

                var controllerType = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name ==
                     expectedController);

                var controller = Activator.CreateInstance(
                    controllerType, this.data, currentUser) as Controller;

                var action = controllerType.GetMethod(route.ActionName);
                var argumentsToPass = this.MapParameters(route, action);
                try
                {
                    var view = action.Invoke(controller, argumentsToPass) as IView;
                    var output = view.Display();
                    this.writer.Write(output);
                    currentUser = controller.CurrentUser;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException is ArgumentException ||
                        ex.InnerException is AuthorizationFailedException)
                    {
                        this.writer.Write(ex.InnerException.Message);
                    }
                    else
                    {
                        throw ex.InnerException;
                    }
                }
            }
        }

        private object[] MapParameters(Route route, MethodInfo action)
        {
            var expectedMethodParams = action.GetParameters();
            var argumentsToPass = new List<object>();
            foreach (ParameterInfo param in expectedMethodParams)
            {
                var currentArgument = route.Parameters[param.Name];
                if (param.ParameterType == typeof(int))
                {
                    argumentsToPass.Add(int.Parse(currentArgument));
                }
                else
                {
                    argumentsToPass.Add(currentArgument);
                }
            }

            return argumentsToPass.ToArray();
        }
    }
}
