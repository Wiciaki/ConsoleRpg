namespace ProjektKD.Entities.Monsters
{
    public abstract class Monster : Entity
    {
        public bool CanRetaliate { get; }

        protected Monster(int attack, int maxHp, bool retaliate) : base(attack, maxHp)
        {
            this.CanRetaliate = retaliate;
        }

        public override void NextAttack()
        {
            base.NextAttack();

            if (this.CanRetaliate)
            {
                var extraDmg = this.attacks[0] / 2;
                this.attacks[0] += extraDmg;
                this.descriptions[0] = this.GetName() + $" attacks and retaliates, dealing {extraDmg} dmg";
            }
        }
    }
}