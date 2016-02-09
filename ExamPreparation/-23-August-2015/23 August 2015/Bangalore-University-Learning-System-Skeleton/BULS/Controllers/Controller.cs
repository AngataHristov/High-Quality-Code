namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Core;
    using Enumerations;
    using Exceptions;
    using Interfaces;
    using Models;
    using Utilities;

    public abstract class Controller
    {
        public Controller(IBangaloreUniversityData data, User currentUser)
        {
            this.Data = data;
            this.CurrentUser = currentUser;
        }

        public User CurrentUser { get; protected set; }

        protected IBangaloreUniversityData Data { get; set; }

        protected bool HasCurrentUser
        {
            get { return this.CurrentUser != null; }
        }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(".");
            string baseNamespace = fullNamespace
                .Substring(0, firstSeparatorIndex);

            string controllerName = this.GetType().Name
                .Replace("Controller", string.Empty);

            string actionName = new StackTrace()
                .GetFrame(1)
                .GetMethod().Name;

            string fullPath = string.Format("{0}.Views.{1}.{2}",
                baseNamespace, controllerName, actionName);

            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);

            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(Constants.NoLoggedUserMsg);
            }

            if (!roles.Any(role => this.CurrentUser.IsInRole(role)))
            {
                throw new AuthorizationFailedException(Constants.NoAutorizedUserMsg);
            }
        }
    }
}
