
namespace Point3D.Point
{
    using System;
    using System.IO;
    using System.Linq;

    public static class Storage
    {
        public static void SavePath(Path3D info)
        {
            string path = "../../path.txt";
            try
            {
                StreamWriter writer = new StreamWriter(path);

                using (writer)
                {
                    foreach (Point3D point in info.ListOfPoints)
                    {
                        writer.WriteLine("[{0},{1},{2}]", point.X, point.Y, point.Z);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Invalid filepath!");
            }

        }

        public static Path3D LoadPath(string file)
        {
            StringReader reader = new StringReader(file);

            Path3D pointList = new Path3D();

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    decimal[] pointCoords = line.Split(',').Select(decimal.Parse).ToArray();

                    decimal x = pointCoords[0];

                    decimal y = pointCoords[1];

                    decimal z = pointCoords[2];

                    Point3D point = new Point3D(x, y, z);

                    pointList.AddPoint(point);

                    line = reader.ReadLine();
                }

                return pointList;
            }
        }
    }
}
