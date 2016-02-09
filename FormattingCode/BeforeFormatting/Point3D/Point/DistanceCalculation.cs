
namespace Point3D.Point
{
    using System;

    public static class DistanceCalculation
    {
        public static decimal CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            decimal result = new decimal();

            decimal xDistance = (firstPoint.X - secondPoint.X) * (firstPoint.X - secondPoint.X);

            decimal yDistance = (firstPoint.Y - secondPoint.Y) * (firstPoint.Y - secondPoint.Y);

            decimal zDistance = (firstPoint.Z - secondPoint.Z) * (firstPoint.Z - secondPoint.Z);

            result = (decimal)Math.Sqrt((double)(xDistance + yDistance + zDistance));

            return result;
        }
    }
}
