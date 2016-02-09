
namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileExtensionUtils.GetFileExtension("example"));
            Console.WriteLine(FileExtensionUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileExtensionUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileExtensionUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileExtensionUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileExtensionUtils.GetFileNameWithoutExtension("example.new.pdf"));

            MakeBounderies();

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                DistanceUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                DistanceUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            MakeBounderies();

            Paralelepiled paralelepiped = new Paralelepiled(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", MathUtils.CalcVolume(paralelepiped));
            Console.WriteLine("Diagonal XYZ = {0:f2}", MathUtils.CalcDiagonalXYZ(paralelepiped));
            Console.WriteLine("Diagonal XY = {0:f2}", MathUtils.CalcDiagonalXY(paralelepiped));
            Console.WriteLine("Diagonal XZ = {0:f2}", MathUtils.CalcDiagonalXZ(paralelepiped));
            Console.WriteLine("Diagonal YZ = {0:f2}", MathUtils.CalcDiagonalYZ(paralelepiped));
        }

        public static void MakeBounderies()
        {
            Console.WriteLine(new string('-', 40));
        }
    }
}
