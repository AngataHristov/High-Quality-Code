using System;

namespace Methods
{
    public class Student
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName, string otherInfo, string dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
            this.DateOfBirth = dateOfBirth;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null.");
                }

                this.lastName = value;
            }
        }

        public string DateOfBirth { get; private set; }

        public string OtherInfo { get; set; }
    }
}
