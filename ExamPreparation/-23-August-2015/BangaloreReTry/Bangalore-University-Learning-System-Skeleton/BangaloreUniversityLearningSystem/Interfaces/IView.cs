namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Text;

    public interface IView
    {
        object Model { get; }

        string Display();

       // void BuildViewResult(StringBuilder viewResult);
    }
}