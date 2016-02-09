
namespace Methods
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class MethodsMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Area:{0}", CalcUtils.CalcTriangleArea(3, 4, 5));
            MakeBounderies();

            Console.WriteLine(FormatUtils.ConvertDigitToString(5));
            MakeBounderies();

            Console.WriteLine("Max number: {0}", CalcUtils.FindMaxNumberFromSequence(5, -1, 3, 2, 14, 2, 3));
            MakeBounderies();

            FormatUtils.PrintNumberInFormat(1.3, "f");
            FormatUtils.PrintNumberInFormat(0.75, "%");
            FormatUtils.PrintNumberInFormat(2.30, "r");
            MakeBounderies();

            Point firstPoint = new Point(3, -1);
            Point secondPoint = new Point(3, 2.5);

            bool horizontal = CalcUtils.IsHorizontal(firstPoint, secondPoint);
            bool vertical = CalcUtils.IsVertical(firstPoint, secondPoint);

            Console.WriteLine("Distance: {0}", CalcUtils.CalcDistance(firstPoint, secondPoint));
            MakeBounderies();

            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);
            MakeBounderies();

            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992", "17/03/1992");

            Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993", "03/11/1993");
            
            Console.WriteLine("{0} older than {1} -> {2}",
                    peter.FirstName, stella.FirstName, StudentsSystemUtils.CompareStudentAge(peter, stella));
            MakeBounderies();
        }

        public static void MakeBounderies()
        {
            Console.WriteLine(new string('-', 40));
        }
    }
}
