
namespace Empires.Models.Interfaces
{
    /// <summary>
    /// Abstraction of the units in the app
    /// </summary>
    public interface IUnit
    {
        // Unit's health
        int Health { get; }

        // Unit's damage
        int AttackDamage { get; }
    }
}
