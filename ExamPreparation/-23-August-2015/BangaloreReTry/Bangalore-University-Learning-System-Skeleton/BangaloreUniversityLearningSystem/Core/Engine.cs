namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Data;
    using Infrastructure;
    using Interfaces;

    public class Engine : IEngine
    {
        public void Run()
        {
            var db = new BangaloreUniversityData();
            User currentUser = null;
            while (true)
            {
                string str = Console.ReadLine();
                if (str == null)
                {
                    break;
                }
                var route = new Route(str);
                var controllerType = Assembly.GetExecutingAssembly().GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName)
                    ;
                var controller = Activator.CreateInstance(controllerType, db, currentUser) as Controller;
                var action = controllerType.GetMethod(route.ActionName);
                object[] @params = MapParameters(route, action);
                try
                {
                    var view = action.Invoke(controller, @params) as IView;
                    Console.WriteLine(view.Display());
                    currentUser = controller.usr;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            var parameters = action.GetParameters().Select<ParameterInfo, object>(
                p =>
                {
                    if (p.ParameterType == typeof(int))
                    {
                        return int.Parse(route.Parameters[p.Name]);
                    }
                    else
                    {
                        return route.Parameters[p.Name];
                    }
                });

            return parameters.ToArray();
        }
    }
}
