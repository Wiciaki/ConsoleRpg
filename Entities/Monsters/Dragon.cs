namespace ProjektKD.Entities.Monsters
{
    using ProjektKD.Entities.Attacks;

    public class Dragon : Monster
    {
        public Dragon(int attack, int maxHp) : base(GetAttacks(attack), maxHp)
        {

        }

        private static Attack[] GetAttacks(int attack)
        {
            var fireball = new DragonAttack(attack * 2, attack * 3, "The Dragon launches a fireball, dealing [0] dmg");
            var basic = new BasicAttack(attack, "The dragon strikes dealing [0] dmg");

            return new Attack[] { fireball, basic };
        }

        public override string GetDescription()
        {
            return "A tough enemy. Is very durable and has a fireball attack that can sometimes burn you\n\t80-120 HP, 12 attack, fireball ability";
        }

        private class DragonAttack : Attack
        {
            public DragonAttack(int minDamage, int maxDamage, string message) : base(minDamage, maxDamage, 0, 0, message, "")
            {

            }

            public override bool IsAvailable(int availableMana)
            {
                return this.Random.Next(0, 1) == 0;
            }
        }
    }
}