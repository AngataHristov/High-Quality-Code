namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines route, holding collection of parameters,
    /// name of controller and name of action.
    /// </summary>
    public interface IRoute
    {
        /// <summary>
        /// The current controller name.
        /// </summary>
        string ControllerName { get; }

        /// <summary>
        /// The current action name.
        /// </summary>
        string ActionName { get; }

        /// <summary>
        /// Collection for saving parameters
        ///  from input as key-value pairs.
        /// </summary>
        IDictionary<string, string> Parameters { get; }
    }
}
