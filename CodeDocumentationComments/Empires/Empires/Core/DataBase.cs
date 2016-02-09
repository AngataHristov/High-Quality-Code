
namespace Empires.Core
{
    using System.Collections.Generic;
    using Enumerations;
    using Interfaces;
    using Models.Interfaces;

    public class DataBase : IDataBase
    {
        private readonly IList<IBuilding> allBuildings;
        private readonly IList<IUnit> allUnits;
        private readonly IDictionary<ResourceTypes, int> resources;
        private readonly IDictionary<UnitTypes, int> units;

        public DataBase()
        {
            this.allBuildings = new List<IBuilding>();
            this.allUnits = new List<IUnit>();
            this.resources = new Dictionary<ResourceTypes, int>();
            this.units = new Dictionary<UnitTypes, int>();
        }

        public IEnumerable<IBuilding> AllBuildings
        {
            get { return this.allBuildings; }
        }

        public IEnumerable<IUnit> AllUnits
        {
            get { return this.allUnits; }
        }

        public IDictionary<ResourceTypes, int> Resources
        {
            get { return this.resources; }
        }

        public IDictionary<UnitTypes, int> Units
        {
            get { return this.units; }
        }

        public void AddUnit(IUnit unit)
        {
            this.allUnits.Add(unit);
        }

        public void AddBuilding(IBuilding building)
        {
            this.allBuildings.Add(building);
        }
    }
}
