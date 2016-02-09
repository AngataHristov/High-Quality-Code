
namespace Empires.Models.Units
{
    using System;

    using Interfaces;

    public abstract class Unit : IUnit
    {
        private int health;

        private int attackDamage;

        protected Unit(int health, int attackDamage)
        {
            this.Health = health;
            this.AttackDamage = attackDamage;
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Health cannot be negative!");
                }

                this.health = value;
            }
        }

        public int AttackDamage
        {
            get
            {
                return this.attackDamage;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Damage cannot be negative!");
                }

                this.attackDamage = value;
            }
        }
    }
}
