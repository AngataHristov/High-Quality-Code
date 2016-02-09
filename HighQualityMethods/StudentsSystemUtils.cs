
namespace Methods
{
    using System;
    using System.Globalization;

    public static class StudentsSystemUtils
    {
        private static DateTime GetDateOfBirth(Student student)
        {
            DateTime date =
                DateTime.ParseExact(student.DateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return date;
        }

        public static bool CompareStudentAge(Student firstStudent, Student secondStudent)
        {
            return GetDateOfBirth(firstStudent) > GetDateOfBirth(secondStudent);
        }
    }
}
