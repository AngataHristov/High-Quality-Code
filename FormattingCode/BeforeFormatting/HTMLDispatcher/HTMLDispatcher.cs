
namespace HTMLDispatcher
{
    using System;

    public static class HTMLDispatcher
    {
        public static string CreateImage(string imagSource, string alt, string title)
        {
            ElementBuilder element = new ElementBuilder("img");

            element.AddAttribute("src", imagSource);

            element.AddAttribute("alt", alt);

            element.AddAttribute("title", title);

            return element.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            ElementBuilder e = new ElementBuilder("a");
            e.AddAttribute("href", url);
            e.AddAttribute("title", title);
            e.AddContent(text);

            return e.ToString();
        }

        public static string CreateInput(string inputType, string name, string value)
        {
            ElementBuilder e = new ElementBuilder("input");
            e.AddAttribute("type", inputType);
            e.AddAttribute("name", name);
            e.AddAttribute("value", value);

            return e.ToString();
        }
    }
}
