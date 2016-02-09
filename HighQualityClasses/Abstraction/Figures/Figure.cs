
namespace Abstraction.Figures
{
    using System;

    using Interfaces;

    public abstract class Figure : IFigure
    {
        public abstract double Area { get; }

        public abstract double Perimeter { get; }

        public override string ToString()
        {
            string toString = string.Format(
                "My perimeter is {0:f2}. My surface is {1:f2}.",
                this.Perimeter,
                this.Area);

            return toString;
        }
    }
}
