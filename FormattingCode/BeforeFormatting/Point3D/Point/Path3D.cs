
namespace Point3D.Point
{
    using System;
    using System.Collections.Generic;

    public class Path3D
    {
        private List<Point3D> listOfPoints;

        public Path3D()
        {
            this.ListOfPoints = new List<Point3D>();
        }

        public List<Point3D> ListOfPoints
        {
            get
            {
                return new List<Point3D>(this.listOfPoints);
            }
           private set
            {
                this.listOfPoints = value;
            }
        }

        public void AddPoint(Point3D point)
        {
            this.listOfPoints.Add(point);
        }
    }
}
