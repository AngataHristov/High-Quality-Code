
namespace Abstraction.Figures
{
    using System;

    using Interfaces;

    public class Circle : Figure, ICircle
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Radius cannot be negative.");
                }

                this.radius = value;
            }
        }

        public override double Area
        {
            get
            {
                return Math.PI * this.Radius * this.Radius;
            }
        }

        public override double Perimeter
        {
            get
            {
                return 2 * Math.PI * this.Radius;
            }
        }

        public override string ToString()
        {
            string toString = string.Format("I`m a circle. {0}", base.ToString());
            return toString;
        }
    }
}
