
namespace Point3D
{
    using System;

    using Point3D.Point;

    public class EntryPoint
    {
        public static void Main()
        {
            // The first three problems are in this project

            Point3D point = new Point3D(5.4m, 6.6m, 3.1m);

            Console.WriteLine(point);

            Point3D anotherPoint = new Point3D(1m, 5.78m, -2.75m);

            Console.WriteLine(anotherPoint);

            Console.WriteLine("{0:F3}", DistanceCalculation.CalculateDistance(point, anotherPoint));

            Point3D basePoint = Point3D.StartingPoint;

            Console.WriteLine(basePoint);

            Path3D listOfPoints = new Path3D();

            listOfPoints.AddPoint(point);
            listOfPoints.AddPoint(basePoint);
            listOfPoints.AddPoint(anotherPoint);

            Storage.SavePath(listOfPoints);
        }
    }
}
