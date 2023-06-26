namespace ProjektKD.Entities.Heroes
{
    using System.Linq;

    using ProjektKD.Entities.Attacks;

    public class Archer : Hero
    {
        public Archer(int attack, int maxHp, int maxMana) : base(GetAttacks(attack), maxHp, maxMana)
        {

        }

        public override string GetDescription()
        {
            return "The Archer has a bow which lets him take down his prey from impressive distance\n\tStart your combat 4 hexes away from the enemy\n\n\tPros:\n\t- Starts combat far away from the enemy\n\t- Deals extra damage based on distance\n\n\tCons:\n\t- Single attack option\n\t- Ineffective in close combat";
        }

        private static Attack[] GetAttacks(int attack)
        {
            var basic = new BasicAttack(attack, $"Shot an enemy, dealing {0} dmg", "Shoot an arrow");
            var spell = new ArcherAttack(attack, $"Hail of arrows landed, dealing {0} dmg", $"Launch a hail of arrows (25 dmg, 10 mana)");

            return new Attack[] { basic, spell }.Concat(Sign.SignList).ToArray();
        }

        private class ArcherAttack : Attack
        {
            public ArcherAttack(int attack, string message, string description) : base(attack, attack, 10, 0, message, description)
            {

            }
        }
    }
}