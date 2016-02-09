
namespace Empires.Models.Units
{
    public class Swordsman : Unit
    {
        private const int HealthDefault = 40;
        private const int AttackDamageDefault = 13;

        public Swordsman()
            : base(HealthDefault, AttackDamageDefault)
        {

        }
    }
}
