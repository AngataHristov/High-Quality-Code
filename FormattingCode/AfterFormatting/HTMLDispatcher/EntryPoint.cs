
namespace HTMLDispatcher
{
    using System;

    public class EntryPoint
    {
        public static void Main()
        {
            ElementBuilder div = new ElementBuilder("div");

            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");

            Console.WriteLine(div * 2);
            Console.WriteLine();

            ElementBuilder li = new ElementBuilder("li");

            li.AddAttribute("class", "nav");
            li.AddAttribute("id", "one");
            li.AddContent("Hello OOP");

            Console.WriteLine(li * 3);
            Console.WriteLine();

            string image = HTMLDispatcher.CreateImage("img.png", "sample img", "sample");
            string url = HTMLDispatcher.CreateURL("https:\\\\softuni.bg", "SoftUni", "SoftUni website");
            string input = HTMLDispatcher.CreateInput("text", "username", "student");

            Console.WriteLine(image);
            Console.WriteLine(url);
            Console.WriteLine(input);
        }
    }
}
