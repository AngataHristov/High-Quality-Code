namespace BuhtigIssueTracker.Core.Trackers
{
    using Interfaces;

    public abstract class Tracker
    {
        protected Tracker(IDatabase data)
        {
            this.Data = data;
        }

        public IDatabase Data { get; set; }
    }
}
