
namespace Abstraction
{
    using System;
    using Figures;

    public class FiguresExample
    {
        public static void Main()
        {
            Circle circle = new Circle(5);

            Console.WriteLine(circle);

            Console.WriteLine(new string('-', 60));

            Rectangle rect = new Rectangle(2, 3);

            Console.WriteLine(rect);
        }
    }
}
