namespace Methods
{
    using System;

    public static class CalcUtils
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            if (a + b < c || a + c < b || b + c < a)
            {
                throw new ArgumentException("Sum of two sides must be bigger than other one.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        public static int FindMaxNumberFromSequence(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Collection of numbers cannot be null. ");
            }

            int maxNumber = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxNumber)
                {
                    maxNumber = elements[i];
                }
            }
            return maxNumber;
        }

        public static double CalcDistance(Point firstPoint, Point seconPoint)
        {
            double xDistance = (seconPoint.X - firstPoint.X) * (seconPoint.X - firstPoint.X);
            double yDistance = (seconPoint.Y - firstPoint.Y) * (seconPoint.Y - firstPoint.Y);

            double distance = Math.Sqrt(xDistance + yDistance);

            return distance;
        }

        public static bool IsHorizontal(Point firstPoint, Point secondPoint)
        {
            bool isHorizontal = (firstPoint.Y == secondPoint.Y);

            return isHorizontal;
        }

        public static bool IsVertical(Point firstPoint, Point seconPoint)
        {
            bool isVertical = (firstPoint.X == seconPoint.X);

            return isVertical;
        }
    }
}