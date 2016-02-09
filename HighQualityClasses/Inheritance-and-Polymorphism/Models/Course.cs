
namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public abstract class Course : ICourse
    {
        private IList<string> students;
        private string name;
        private string teacherName;

        protected Course(string name)
        {
            this.Name = name;
            this.students = new List<string>();
        }

        protected Course(string courseName, string teacherName)
            : this(courseName)
        {
            this.TeacherName = teacherName;
        }

        protected Course(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName)
        {
            this.students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null ot empty.");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("TeacherName cannot be null ot empty.");
                }

                this.teacherName = value;
            }
        }

        public IEnumerable<string> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = new List<string>(value);
            }
        }

        public void AddStudent(string student)
        {
            this.students.Add(student);
        }

        protected string GetStudentsAsString()
        {
            if (this.Students == null)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
