
namespace Empires.Models.Units
{
    public class Archer : Unit
    {
        private const int HealthDefault = 25;
        private const int AttackDamageDefault = 7;

        public Archer()
            : base(HealthDefault, AttackDamageDefault)
        {

        }
    }
}
