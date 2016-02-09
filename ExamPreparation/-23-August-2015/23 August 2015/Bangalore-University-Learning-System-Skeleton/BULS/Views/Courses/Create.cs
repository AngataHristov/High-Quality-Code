namespace BangaloreUniversityLearningSystem.Views.Courses
{
    using System.Text;
    using Core;
    using Models;
    using Users;

    public class Create : View
    {
        public Create(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;

            viewResult
                .AppendFormat(Constants.CourseCreatedSuccessfullyMsg, course.Name)
                .AppendLine();
        }
    }
}
