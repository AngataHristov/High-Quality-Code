namespace CohesionAndCoupling
{
    using System;

    public class Paralelepiled
    {
        private double width;
        private double height;
        private double depth;

        public Paralelepiled(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
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

        public double Depth
        {
            get
            {
                return this.depth;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Depth cannot be negative.");
                }

                this.depth = value;
            }
        }
    }
}