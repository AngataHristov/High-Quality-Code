
namespace Point3D.Point
{
    using System;

    public class Point3D
    {
        private static readonly decimal startX = 0;

        private static readonly decimal startY = 0;

        private static readonly decimal startZ = 0;

        public Point3D(decimal x, decimal y, decimal z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public decimal X { get; private set; }

        public decimal Y { get; private set; }

        public decimal Z { get; private set; }

        public static Point3D StartingPoint = new Point3D(0, 0, 0);
        //{
        //    get
        //    {
        //        return new Point3D(startX, startY, startZ);
        //    }
        //}

        public override string ToString()
        {
            return string.Format("Point with coordinates: [{0}, {1}, {2}]", this.X, this.Y, this.Z);
        }

    }
}
