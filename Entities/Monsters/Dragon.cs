namespace ProjektKD.Entities.Monsters
{
    public class Dragon : Monster
    {
        public Dragon(int attack, int maxHp) : base(attack, maxHp, false)
        {

        }

        public override string GetDescription()
        {
            return "A tough enemy. Is very durable and has a fireball attack that can sometimes burn you\n\t80-120 HP, 12 attack, fireball ability";
        }

        public override void NextAttack()
        {
            base.NextAttack();

            if (R.Next(0, 1) == 0)
            {
                var extraDmg = this.attacks[0] * 3 / 2;
                this.attacks[0] += extraDmg;
                this.descriptions[0] = $"The Dragon launches a fireball, dealing {this.attacks[0]} dmg";
            }
        }
    }
}