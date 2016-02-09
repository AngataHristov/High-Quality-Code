

namespace Empires.Core.Commands
{
    using System;
    using System.Text;
    using System.Linq;
    using Enumerations;
    using Interfaces;
    using Models.Buildings;
    using Models.Interfaces;
    using Models.Resources;
    using Models.Units;

    public class StatusCommand : CommandAbstract
    {
        public StatusCommand(IEngine engine)
            : base(engine)
        {

        }

        public override void Execute()
        {
            StringBuilder resul = new StringBuilder();

            resul.AppendLine("Treasury:");
            resul.AppendLine(string.Format("--Gold: {0}", CalcAllGold()));
            resul.AppendLine(string.Format("--Steel: {0}", CalcAllSteel()));

            resul.AppendLine("Buildings:");

            int allTurns = new int();

            foreach (var building in this.Engine.DB.AllBuildings)
            {
                allTurns = building.CycleCounter;

                resul.AppendLine(string.Format("--{0}", building is Barracks ?
                    string.Format("{0}: {1} turns {2}", "Barracks", allTurns, string.Format("({0} turns until Swordsman, {1} turns until Steel)", 4 - building.UnitCycle,
                    3 - building.ResourceCycle)) :
                    string.Format("{0}: {1} turns {2}", "Archery", allTurns, string.Format("({0} turns until Archer, {1} turns until Gold)",
                    3 - building.UnitCycle, 2 - building.ResourceCycle))));
            }

            resul.AppendLine("Units:");

            var firstBuilding = this.Engine.DB.AllBuildings
                .First();

            if (firstBuilding is Archery)
            {
                if (CalcAllArchers() != 0 && CalcAllSwordsman() != 0)
                {
                    resul.AppendLine(string.Format("--Archer: {0}", CalcAllArchers()));
                    resul.Append(string.Format("--Swordsman: {0}", CalcAllSwordsman()));
                }
                else if (CalcAllArchers() != 0 && CalcAllSwordsman() == 0)
                {
                    resul.Append(string.Format("--Archer: {0}", CalcAllArchers()));
                }
                else if (CalcAllArchers() == 0 && CalcAllSwordsman() != 0)
                {
                    resul.Append(string.Format("--Swordsman: {0}", CalcAllSwordsman()));
                }

            }
            else if (firstBuilding is Barracks && CalcAllArchers() != 0 && CalcAllSwordsman() != 0)
            {
                resul.AppendLine(string.Format("--Swordsman: {0}", CalcAllSwordsman()));
                resul.Append(string.Format("--Archer: {0}", CalcAllArchers()));
            }
            else if (CalcAllArchers() != 0 && CalcAllSwordsman() == 0)
            {
                resul.Append(string.Format("--Archer: {0}", CalcAllArchers()));
            }
            else if (CalcAllArchers() == 0 && CalcAllSwordsman() != 0)
            {
                resul.Append(string.Format("--Swordsman: {0}", CalcAllSwordsman()));
            }

            if (CalcAllArchers() == 0 && CalcAllSwordsman() == 0)
            {
                resul.Append("N/A");
            }

            this.Engine.Writer.Write(resul.ToString());
        }

        private int CalcAllGold()
        {
            int allGold = new int();
            foreach (var building in this.Engine.DB.AllBuildings)
            {
                allGold += building.Resources
                    .Where(r => r.Type == ResourceTypes.Gold)
                    .Select(g => g.Quantity)
                    .Sum();
            }

            return allGold;
        }

        private int CalcAllSteel()
        {
            int allSteel = new int();
            foreach (var building in this.Engine.DB.AllBuildings)
            {
                allSteel += building.Resources
                    .Where(r => r.Type == ResourceTypes.Steel)
                    .Select(s => s.Quantity)
                    .Sum();
            }

            return allSteel;
        }

        private int CalcAllArchers()
        {
            int AllArchers = this.Engine.DB.AllUnits
                .Count(u => u is Archer);

            return AllArchers;
        }

        private int CalcAllSwordsman()
        {
            int AllSwordsman = this.Engine.DB.AllUnits
                .Count(u => u is Swordsman);

            return AllSwordsman;
        }
    }
}
