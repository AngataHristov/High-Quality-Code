
namespace Abstraction.Figures
{
    using System;

    using Interfaces;

    public class Rectangle : Figure, IRectangle
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double Area
        {
            get
            {
                return this.Width * this.Height;
            }
        }

        public override double Perimeter
        {
            get
            {
                return 2 * (this.Width + this.Height);
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width cannot be negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height cannot be negative.");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            string toString = string.Format("I`m a rectangle. {0}", base.ToString());
            return toString;
        }
    }
}
