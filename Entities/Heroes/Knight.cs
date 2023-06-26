namespace ProjektKD.Entities.Heroes
{
    using System.Linq;

    using ProjektKD.Entities.Attacks;

    public class Knight : Hero
    {
        public Knight(int attack, int maxHp, int maxMana) : base(GetAttacks(attack), maxHp, maxMana)
        {

        }

        private static Attack[] GetAttacks(int attack)
        {
            var basic = new BasicAttack(attack, "The Knight attacks, dealing {0} damage", "Use normal attack");
            var powerful = new KnightAttack(attack, "Ouch! This really hurt. You did {0} dmg", "Charge powerful attack (60% chance to hit)");

            return new Attack[] { basic, powerful }.Concat(Sign.SignList).ToArray();
        }

        public override string GetDescription()
        {
            return "The Knight is a heavily armoured unit and he does not fear any enemy\n\tYou can use a normal attack, or charge a powerful strike with double the damage but a 40% chance to miss\n\n\tPros: Highest base stats\n\tCons: No ranged attack";
        }

        private class KnightAttack : Attack
        {
            public KnightAttack(int attack, string message, string description) : base(attack * 2 - 4, attack * 2 + 4, 0, 0, message, description)
            {

            }

            public override AttackResult Execute()
            {
                if (this.Random.Next(0, 100) >= 60)
                {
                    return new AttackResult(0, 0, 0, "You missed!");
                }

                return base.Execute();
            }
        }
    }
}