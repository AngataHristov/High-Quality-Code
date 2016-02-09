
namespace Empires.Models.Interfaces
{
    using System.Collections.Generic;

    using Empires.Interfaces;

    /// <summary>
    /// Abstraction of the buildings in the app
    /// </summary>
    public interface IBuilding
    {
        // Repository of the produced units
        IEnumerable<IUnit> Units { get; }

        // Repository of the produced resources
        IEnumerable<IResource> Resources { get; }

        // Adds unit to units repository
        void AddUnit(IUnit unit);

        // Adds resource to resources repository
        void AddResource(IResource resource);

        // Counts the turns of the building
        int CycleCounter { get; }

        // Counts the cycles of the resources creation
        int ResourceCycle { get; }

        // Counts the cycles of the units creation
        int UnitCycle { get; }

        // App engine
        IEngine Engine { get; }

        // Update the state ot the building
        void Update();
    }
}
