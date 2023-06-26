namespace ProjektKD.Entities.Heroes
{
    using System.Linq;

    using ProjektKD.Entities.Attacks;

    public class Wizard : Hero
    {
        public Wizard(int attack, int maxHp, int maxMana) : base(GetAttacks(attack), maxHp, maxMana)
        {

        }

        public override string GetDescription()
        {
            return "The wizard is very wise and has access to a powerful spell - 'fireball'\n\tYou also start combat 4 hexes away from the enemy\n\n\tPros: High spell damage\n\tCons: Lowest base stats";
        }

        private static Attack[] GetAttacks(int attack)
        {
            var basic = new BasicAttack(attack, "Lightning bolt strikes, dealing {0} damage", "Lightning bolt");
            var fireball = new Attack(attack * 2, attack * 2, 8, 0, "You burned your enemy, dealing {0} dmg", "Fireball (8 mana)");
            var fireballHeal = new Attack(attack * 2, attack * 2, 15, 20, "You burned your enemy, dealing {0} dmg\t\tYou've also healed 20HP", "Fireball + selfheal (15 mana)");

            return new Attack[] { basic, fireball, fireballHeal }.Concat(Sign.SignList).ToArray();
        }
    }
}