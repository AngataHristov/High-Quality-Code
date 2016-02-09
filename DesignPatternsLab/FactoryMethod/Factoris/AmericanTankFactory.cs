namespace FactoryMethod.Factoris
{
    using TankManufacturer.Units;

    public class AmericanTankFactory : TankFactory
    {
        private const string ManufacturesDefault = "M1 Abrams";
        private const double SpeedDefault = 5.4;
        private const int DamageDefault = 120;

        public override Tank CreateTank()
        {
            return new Tank(ManufacturesDefault, SpeedDefault, DamageDefault);
        }
    }
}
