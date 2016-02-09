
namespace Empires.Models.Buildings
{
    using Empires.Interfaces;
    using Resources;
    using Units;

    public class Barracks : Building
    {   
        public Barracks(IEngine engine)
        : base(engine)
        {

        }

        public override void Update()
        {
            base.Update();

            if (this.CycleCounter % 3 == 0 && this.CycleCounter != 0)
            {
                var steel = new Steel();
                this.AddResource(steel);
                this.ResourceCycle = 0;
            }
            if (this.CycleCounter % 4 == 0 && this.CycleCounter != 0)
            {
                var swordsman = new Swordsman();
                this.AddUnit(swordsman);
                this.Engine.DB.AddUnit(swordsman);
                this.UnitCycle = 0;
            }
        }
    }
}
