namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;
    using Core;
    using Enumerations;
    using Exceptions;
    using Interfaces;
    using Models;
    using Utilities;

    public class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityData data, User currentUser)
            : base(data, currentUser)
        {
        }

        public IView All()
        {
            return this.View(this.Data.Courses.GetAll()
                       .OrderBy(c => c.Name)
                       .ThenByDescending(c => c.Students.Count));
        }

        public IView Details(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.GetCourseById(courseId);
            var isInCourse = course.Students.Any(u => u == this.CurrentUser);
            if (!isInCourse)
            {
                throw new ArgumentException(Constants.NotInCourseMsg);
            }

            return this.View(course);
        }

        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.GetCourseById(courseId);

            if (this.CurrentUser.Courses.Contains(course))
            {
                throw new ArgumentException(Constants.AlreayEnroledInCourseMsg);
            }

            course.AddStudent(this.CurrentUser);
            this.CurrentUser.AddCource(course);

            return this.View(course);
        }

        public IView Create(string name)
        {
            this.EnsureAuthorization(Role.Lecturer);
            //if (!this.HasCurrentUser)
            //{
            //    throw new ArgumentException(Constants.NoCurrentlyLoggedUserMsg);
            //}

            //if (!this.CurrentUser.IsInRole(Role.Lecturer))
            //{
            //    throw new AuthorizationFailedException(Constants.NotAuthorizedUserMsg);
            //}
            var course = new Course(name);

            this.Data.Courses.Add(course);

            return this.View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            this.EnsureAuthorization(Role.Lecturer);

            //if (!this.HasCurrentUser)
            //{
            //    throw new ArgumentException(Constants.NoCurrentlyLoggedUserMsg);
            //}

            //if (!this.CurrentUser.IsInRole(Role.Lecturer))
            //{
            //    throw new AuthorizationFailedException(Constants.NotAuthorizedUserMsg);
            //}

            Course course = this.GetCourseById(courseId);

            course.AddLecture(new Lecture(lectureName));

            return this.View(course);
        }

        private Course GetCourseById(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format(Constants.NoCoursesWithIDMsg, courseId));
            }

            return course;
        }
    }
}
