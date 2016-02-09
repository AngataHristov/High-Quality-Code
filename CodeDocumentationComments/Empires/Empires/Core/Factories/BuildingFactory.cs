using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Core.Factories
{
    using Interfaces;
    using Models.Buildings;
    using Models.Interfaces;
    using Models.Units;

    public static class BuildingFactory
    {
        public static IBuilding Create(string buildingType, IEngine engine)
        {
            switch (buildingType)
            {
                case "archery":
                    return new Archery(engine);
                case "barracks":
                    return new Barracks(engine);
                default:
                    throw new NotSupportedException("Invalid type supplied");
            }
        }
    }
}

