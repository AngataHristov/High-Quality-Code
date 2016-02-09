namespace BangaloreUniversityLearningSystem.Views.Courses
{
    using System.Text;
    using Core;
    using Models;
    using Users;

    public class Enroll : View
    {
        public Enroll(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat(Constants.StudentSuccessfullyEnrolledInCourseMsg, course.Name).AppendLine();
        }
    }
}
