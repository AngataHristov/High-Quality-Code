namespace BuhtigIssueTracker.Interfaces
{
    public interface IDispatcher
    {
        string DispatchAction(IEndpoint endpoint);
    }
}
