
namespace TravelAgency.Interfaces
{
    public interface IOutputWriter
    {
        void Write(string line);

        void Flush();
    }
}
