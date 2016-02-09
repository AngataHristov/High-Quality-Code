namespace BangaloreUniversityLearningSystem
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Interfaces;
    using Utilities;

    public class Route : IRoute
    {
        public Route(string routeUrl)
        {
            this.Parse(routeUrl);
        }

        public IDictionary<string, string> Parameters { get; private set; }

        private void Parse(string routeUrl)
        {
            string[] parts = routeUrl.Split(
                new[] { "/", "?" },
                StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
                throw new InvalidOperationException(Constants.InvalidProvidetRouteMsg);
            this.ControllerName = parts[0] + "Controller";
            this.ActionName = parts[1];
            if (parts.Length >= 3)
            {
                this.Parameters = new Dictionary<string, string>();
                string[] parameterPairs = parts[2].Split('&');
                foreach (var pair in parameterPairs)
                {
                    string[] name_value = pair.Split('=');
                    this.Parameters.Add(WebUtility.UrlDecode(name_value[1]), WebUtility.UrlDecode(name_value[0]));
                }
            }
        }

        public string ActionName { get; private set; }

        public string ControllerName { get; private set; }
    }
}