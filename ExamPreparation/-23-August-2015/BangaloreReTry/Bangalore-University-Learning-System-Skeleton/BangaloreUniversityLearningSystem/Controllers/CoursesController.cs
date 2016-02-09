namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;
    using Enumerations;
    using Infrastructure;
    using Interfaces;
    using Utilities;

    class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityData data, User user)
        {
            this.Data = data;
            this.usr = user;
        }

        public IView All()
        {
            return this.View(this.Data.Courses.GetAll().OrderBy(c => c.Name).ThenByDescending(c => c.Students.Count));
        }

        public IView Details(int courseId)
        {
            // TODO: Implement me
            throw new NotImplementedException();
        }

        public IView Enroll(int id)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var c = this.Data.Courses.Get(id);
            if (c == null)
                throw new ArgumentException(string.Format("There is no course with ID {0}.", id));
            if (this.usr.Courses.Contains(c))
                throw new ArgumentException("You are already enrolled in this course.");
            c.AddStudent(this.usr);
            return this.View(c);
        }

        private Course courseGetter(int c_id)
        {
            var course = this.Data.Courses.Get(c_id);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", c_id));
            }
            return course;
        }

        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
                throw new ArgumentException("There is no currently logged in user.");
            if (this.usr.IsInRole(Role.Lecturer))
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");

            var c = new Course(name);
            this.Data.Courses.Add(c);
            return this.View(c);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.usr.IsInRole(Role.Lecturer))
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");

            Course c = this.courseGetter(courseId);
            c.AddLecture(new Lecture("lectureName"));
            return this.View(c);
        }
    }
}
