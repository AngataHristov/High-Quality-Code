namespace HotelBookingSystem.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Enums;
    using Exceptions;
    using Identity;
    using Interfaces;
    using Models;
    using Utilities;
    using Views.Shared;

    /// <summary>
    /// Abstract class, defines some methodes for view,
    /// not found message and autorization.
    /// </summary>
    public abstract class Controller
    {
        protected Controller(IHotelBookingSystemData data, User user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        public User CurrentUser { get; set; }

        public bool HasCurrentUser
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

        protected IHotelBookingSystemData Data { get; private set; }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(Constants.NamesapceSeparatorMsg);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace(Constants.ControllerSuffixMsg, string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = string.Join(
                Constants.NamesapceSeparatorMsg,
                new[] { baseNamespace, Constants.ViewsFolderMsg, controllerName, actionName });
            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);

            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected IView NotFound(string message)
        {
            return new Error(message);
        }

        protected void Authorize(params Roles[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(Constants.NoLoggedInUserMsg);
            }

            if (!roles.Any(role => this.CurrentUser.IsInRole(role)))
            {
                throw new AuthorizationFailedException(Constants.NoRightsMsg);
            }
        }
    }
}
