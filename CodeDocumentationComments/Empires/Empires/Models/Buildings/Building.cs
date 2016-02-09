
namespace Empires.Models.Buildings
{
    using System.Collections.Generic;
    using Empires.Interfaces;
    using Interfaces;

    public abstract class Building : IBuilding
    {
        private const int CounterDefault = -1;

        private readonly IList<IUnit> units;

        private readonly IList<IResource> resources;

        public Building(IEngine engine)
        {
            this.units = new List<IUnit>();
            this.resources = new List<IResource>();
            this.CycleCounter = CounterDefault;
            this.Engine = engine;
            this.UnitCycle = -1;
            this.ResourceCycle = -1;
        }

        public IEnumerable<IUnit> Units
        {
            get { return this.units; }
        }

        public IEnumerable<IResource> Resources
        {
            get { return this.resources; }
        }

        public void AddUnit(IUnit unit)
        {
            this.units.Add(unit);
        }

        public void AddResource(IResource resource)
        {
            this.resources.Add(resource);
        }

        public int CycleCounter { get; private set; }

        public int ResourceCycle { get; protected set; }

        public int UnitCycle { get; protected set; }

        public IEngine Engine { get; }

        public virtual void Update()
        {
            this.CycleCounter++;
            this.ResourceCycle++;
            this.UnitCycle ++;
        }
    }
}
