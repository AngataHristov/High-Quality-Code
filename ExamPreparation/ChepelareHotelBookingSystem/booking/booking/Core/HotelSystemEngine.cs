namespace HotelBookingSystem.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Controllers;
    using Infrastructure;
    using Interfaces;
    using Models;
    using Utilities;
    using Views.Shared;

    public class HotelSystemEngine : IEngine
    {
        private readonly IHotelBookingSystemData database;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public HotelSystemEngine(IHotelBookingSystemData database, IInputReader reader, IOutputWriter writer)
        {
            this.database = database;
            this.reader = reader;
            this.writer = writer;
        }

        public void StartOperation()
        {
            User currentUser = null;
            while (true)
            {
                string inputUrl = this.reader.ReadNextLine();
                if (inputUrl == null)
                {
                    break;
                }

                var executionEndpoint = new Endpoint(inputUrl);

                Type controllerType = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == executionEndpoint.ControllerName);

                var controller = Activator.CreateInstance(controllerType, this.database, currentUser) as Controller;
                var action = controllerType.GetMethod(executionEndpoint.ActionName);
                var parameters = MapParameters(executionEndpoint, action);
                string viewResult = string.Empty;
                try
                {
                    var view = action.Invoke(controller, parameters) as IView;
                    viewResult = view.Display();
                    currentUser = controller.CurrentUser;
                }
                catch (Exception ex)
                {
                    viewResult = new Error(ex.InnerException.Message).Display();
                }

                this.writer.Write(viewResult);
            }
        }

        private static object[] MapParameters(IEndpoint executionEndpoint, MethodInfo action)
        {
            var parameters = action
                .GetParameters()
                .Select<ParameterInfo, object>(p =>
                {
                    if (p.ParameterType == typeof(int))
                    {
                        return int.Parse(executionEndpoint.Parameters[p.Name]);
                    }
                    else if (p.ParameterType == typeof(decimal))
                    {
                        return decimal.Parse(executionEndpoint.Parameters[p.Name]);
                    }
                    else if (p.ParameterType == typeof(DateTime))
                    {
                        return DateTime.ParseExact(executionEndpoint.Parameters[p.Name], Constants.DateFormatMsg, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        return executionEndpoint.Parameters[p.Name];
                    }
                })
               .ToArray();

            return parameters;
        }
    }
}
