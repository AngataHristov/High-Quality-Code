namespace BuhtigIssueTracker.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Interfaces;

    public class Endpoint : IEndpoint
    {
        public Endpoint(string inputUrl)
        {
            this.ActionName = this.ExtractAction(inputUrl);
            this.Parameters = this.ParseInput(inputUrl);
        }

        public string ActionName { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        private IDictionary<string, string> ParseInput(string inputUrl)
        {
            var parameters = new Dictionary<string, string>();
            int questionMarkIndex = inputUrl.IndexOf('?');
            if (questionMarkIndex != -1)
            {
                var pairs = inputUrl
                    .Substring(questionMarkIndex + 1)
                    .Split('&')
                    .Select(x => x.Split('=')
                        .Select(xx => WebUtility.UrlDecode(xx)).ToArray());

                foreach (string[] pair in pairs)
                {
                    string key = pair[0];
                    string value = pair[1];

                    parameters.Add(key, value);
                }
            }

            return parameters;
        }

        private string ExtractAction(string inputUrl)
        {
            string action = string.Empty;
            int questionMarkIndex = inputUrl.IndexOf('?');
            if (questionMarkIndex != -1)
            {
                action = inputUrl
                    .Substring(0, questionMarkIndex);
            }
            else
            {
                action = inputUrl;
            }

            return action;
        }
    }
}