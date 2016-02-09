
namespace Empires.Models.Buildings
{
    using Empires.Interfaces;
    using Resources;
    using Units;

    public class Archery : Building
    {
        public Archery(IEngine engine)
        : base(engine)
        {

        }

        public override void Update()
        {
            base.Update();

            if (this.CycleCounter % 2 == 0 && this.CycleCounter != 0)
            {
                var gold = new Gold();
                this.AddResource(gold);
                this.ResourceCycle = 0;
            }
            if (this.CycleCounter % 3 == 0 && this.CycleCounter != 0)
            {
                var archer = new Archer();
                this.AddUnit(archer);
                this.Engine.DB.AddUnit(archer);
                this.UnitCycle = 0;
            }
        }
    }
}
