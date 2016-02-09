
namespace Minesweeper.Core.Commands
{
    using Events;
    using Interfaces;

    public abstract class CommandAbstract : IExecutable
    {
        public event OnRunningChanged OnExecuting;

        protected CommandAbstract(IEngine engine)
        {
            this.Engine = engine;
        }

        public IEngine Engine { get; protected set; }

        public abstract void Execute();

        protected virtual void OnExecute(CommandEventArgs e)
        {
            if (this.OnExecuting != null)
            {
                this.OnExecuting(this, e);
            }
        }
    }
}
