
namespace CohesionAndCoupling
{
    using System;

    public static class MathUtils
    {
        private const double zeroPosition = 0;

        public static double CalcVolume(Paralelepiled paralelepiled)
        {
            double volume = paralelepiled.Width * paralelepiled.Height * paralelepiled.Depth;

            return volume;
        }

        public static double CalcDiagonalXYZ(Paralelepiled paralelepiled)
        {
            double distance = DistanceUtils.CalcDistance3D(zeroPosition, zeroPosition, zeroPosition,
                paralelepiled.Width, paralelepiled.Height, paralelepiled.Depth);

            return distance;
        }

        public static double CalcDiagonalXY(Paralelepiled paralelepiled)
        {
            double distance = DistanceUtils.CalcDistance2D(zeroPosition, zeroPosition,
                paralelepiled.Width, paralelepiled.Height);

            return distance;
        }

        public static double CalcDiagonalXZ(Paralelepiled paralelepiled)
        {
            double distance = DistanceUtils.CalcDistance2D(zeroPosition, zeroPosition,
                paralelepiled.Width, paralelepiled.Depth);

            return distance;
        }

        public static double CalcDiagonalYZ(Paralelepiled paralelepiled)
        {
            double distance = DistanceUtils.CalcDistance2D(zeroPosition, zeroPosition,
                paralelepiled.Height, paralelepiled.Depth);

            return distance;
        }
    }
}
