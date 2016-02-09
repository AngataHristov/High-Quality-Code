
namespace CohesionAndCoupling
{
    using System;

    public static class DistanceUtils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double xDistance = CalcDistanceBetweenTwoPoints(x1, x2);
            double yDistance = CalcDistanceBetweenTwoPoints(y1, y2);

            double distance = Math.Sqrt(xDistance + yDistance);
            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double xDistance = CalcDistanceBetweenTwoPoints(x1, x2);
            double yDistance = CalcDistanceBetweenTwoPoints(y1, y2);
            double zDistance = CalcDistanceBetweenTwoPoints(z1, z2);

            double distance = Math.Sqrt(xDistance + yDistance + zDistance);
            return distance;
        }

        private static double CalcDistanceBetweenTwoPoints(double firstCoordinate, double secondCoordinate)
        {
            double distance = (secondCoordinate - firstCoordinate) *
                (secondCoordinate - firstCoordinate);

            return distance;
        }
    }
}
