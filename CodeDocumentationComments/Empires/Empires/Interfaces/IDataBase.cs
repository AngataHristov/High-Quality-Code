
namespace Empires.Interfaces
{
    using System.Collections.Generic;
    using Enumerations;
    using Models.Interfaces;

    /// <summary>
    /// Application repository
    /// </summary>
    public interface IDataBase
    {
        // Buildings repository
        IEnumerable<IBuilding> AllBuildings { get; }

        // Units repository
        IEnumerable<IUnit> AllUnits { get; }

        // Adds unit to units repository
        void AddUnit(IUnit unit);

        // Adds building to units repository
        void AddBuilding(IBuilding building);
    }
}
