namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Core;
    using Interfaces;

    public class Route : IRoute
    {
        public Route(string routeUrl)
        {
            this.Parse(routeUrl);
        }

        public IDictionary<string, string> Parameters { get; private set; }

        public string ActionName { get; private set; }

        public string ControllerName { get; private set; }

        private void Parse(string routeUrl)
        {
            string[] parsedParts = routeUrl.Split(new[] { "/", "?" }, StringSplitOptions.RemoveEmptyEntries);
            if (parsedParts.Length < 2)
            {
                throw new InvalidOperationException(Constants.InvalidProvidetRouteMsg);
            }

            this.ControllerName = parsedParts[0] + "Controller";
            this.ActionName = parsedParts[1];
            if (parsedParts.Length >= 3)
            {
                this.Parameters = new Dictionary<string, string>();
                string[] parameterPairs = parsedParts[2].Split('&');
                foreach (var pair in parameterPairs)
                {
                    string[] keyValue = pair.Split('=');
                    string key = WebUtility.UrlDecode(keyValue[0]);
                    string value = WebUtility.UrlDecode(keyValue[1]);

                    this.Parameters.Add(key, value);
                }
            }
        }
    }
}