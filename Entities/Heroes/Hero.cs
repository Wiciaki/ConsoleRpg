namespace ProjektKD.Entities.Heroes
{
    using System;

    using ProjektKD.Entities.Attacks;

    public abstract class Hero : Entity
    {
        public int Mana { get; protected set; }

        public int MaxMana { get; protected set; }

        public int RemainingWellTimes { get; private set; }

        public void UseWell()
        {
            this.Hp = Math.Min(this.MaxHp, this.Hp + this.MaxHp / 2);
            this.Mana = this.MaxMana;
            this.RemainingWellTimes--;
        }

        public override Attack[] GetAvailableAttacks()
        {
            return Array.FindAll(base.GetAvailableAttacks(), attack => attack.IsAvailable(this.Mana));
        }

        protected Hero(Attack[] attacks, int maxHp, int maxMana) : base(attacks, maxHp)
        {
            this.MaxMana = maxMana;
            this.Reset();
        }

        public void Reset()
        {
            this.Mana = this.MaxMana;
            this.Hp = this.MaxHp;
            this.RemainingWellTimes = 3;
        }
    }
}