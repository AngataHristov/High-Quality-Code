namespace BangaloreUniversityLearningSystem.Views.Courses
{
    using System.Text;
    using Core;
    using Models;
    using Users;

    public class AddLecture : View
    {
        public AddLecture(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat(Constants.LectureSuccessfullyAddedMsg, course.Name).AppendLine();
        }
    }
}
