namespace FactoryMethod.Factoris
{
    using TankManufacturer.Units;

    public class GermanTankFactory : TankFactory
    {
        private const string ManufacturesDefault = "Tiger";
        private const double SpeedDefault = 4.5;
        private const int DamageDefault = 75;

        public override Tank CreateTank()
        {
            return new Tank(ManufacturesDefault, SpeedDefault, DamageDefault);
        }
    }
}
