using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Core.Factories
{
    using Models.Interfaces;
    using Models.Units;

    public static class UnitFactory
    {
        public static IUnit Create(string unitType)
        {
            switch (unitType)
            {
                case "Archer":
                    return new Archer();
                case "Swordsman":
                    return new Swordsman();
                default:
                    throw new NotSupportedException("Invalid type supplied");
            }
        }
    }
}

