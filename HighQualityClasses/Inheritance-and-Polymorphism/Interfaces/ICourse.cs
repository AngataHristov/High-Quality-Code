
namespace InheritanceAndPolymorphism.Interfaces
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string Name { get; }

        string TeacherName { get; }

        IEnumerable<string> Students { get; }

        void AddStudent(string studentName);
    }
}
