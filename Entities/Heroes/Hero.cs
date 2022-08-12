namespace ProjektKD.Entities.Heroes
{
    using System;

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

        public abstract string[] GetAttackOptions();

        public virtual void UseAttack(int index) { }

        protected Hero(int attack, int maxHp, int maxMana) : base(attack, maxHp)
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