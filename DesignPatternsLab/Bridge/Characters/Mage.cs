namespace Bridge.Characters
{
    using Interfaces;

    public class Mage : IUnut
    {
        public Mage(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public IWeapon Weapon { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} wields weapon {1}",
                this.GetType().Name, this.Weapon.GetType().Name);
        }
    }
}
