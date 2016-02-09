namespace FactoryMethod.Factoris
{
    using TankManufacturer.Units;

    public class RussianTankFactory : TankFactory
    {
        private const string ManufacturesDefault = "T 34";
        private const double SpeedDefault = 3.3;
        private const int DamageDefault = 75;

        public override Tank CreateTank()
        {
            return new Tank(ManufacturesDefault, SpeedDefault, DamageDefault);
        }
    }
}
