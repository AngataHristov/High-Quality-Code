namespace BangaloreUniversityLearningSystem
{
    using System;

    public class Lecture
    {
        public string name;

        public Lecture(string name)
        {
            this.Name = this.Name;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null || value.Length < 3)
                    throw new ArgumentException(string.Format("The lecture name must be at least 3 symbols long."));
                this.name = value;
            }
        }
    }
}