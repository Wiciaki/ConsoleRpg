namespace ProjektKD.Entities.Monsters
{
    using ProjektKD.Entities.Attacks;

    public abstract class Monster : Entity
    {
        public bool CanRetaliate { get; }

        protected Monster(int attack, int maxHp, bool retaliate) : this(GetAttacks(attack, retaliate), maxHp)
        {
            this.CanRetaliate = retaliate;
        }

        protected Monster(Attack[] attacks, int maxHp) : base(attacks, maxHp)
        {

        }

        private static Attack[] GetAttacks(int attack, bool retaliate)
        {
            string msg;

            if (retaliate)
            {
                msg = "Monster retaliates, dealing {0} dmg";
                attack = attack * 3 / 2;
            }
            else
            {
                msg = "Monster attacks, dealing {0} dmg";
            }

            return new Attack[] { new BasicAttack(attack, msg) };
        }

        public virtual string ExtraMessage()
        {
            return "";
        }
    }
}