using System;

namespace Empires.Core.Commands
{
    using System.Linq.Expressions;
    using Engines;
    using Factories;
    using Interfaces;
    using Models.Interfaces;

    public class BuildCommand : CommandAbstract
    {

        public BuildCommand(string type, IEngine engine)
            : base(engine)
        {
            this.Type = type;
        }

        public string Type { get; protected set; }

        public override void Execute()
        {
            var building = BuildingFactory.Create(this.Type, this.Engine);
            this.Engine.DB.AddBuilding(building);

        }
    }
}
