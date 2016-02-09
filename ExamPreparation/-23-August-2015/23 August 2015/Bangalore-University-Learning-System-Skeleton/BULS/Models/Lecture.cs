namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using Core;

    public class Lecture
    {
        private string name;

        public Lecture(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null || value.Length < 3)
                {
                    throw new ArgumentException(Constants.LectureLengthMsg);
                }

                this.name = value;
            }
        }
    }
}
