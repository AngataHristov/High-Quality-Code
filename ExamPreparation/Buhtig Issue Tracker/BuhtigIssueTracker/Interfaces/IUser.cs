namespace BuhtigIssueTracker.Interfaces
{
    public interface IUser
    {
        string UserName { get; }

        string HashedPassword { get; }
    }
}