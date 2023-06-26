namespace ProjektKD.Entities
{
    using System;

    using ProjektKD.Entities.Attacks;

    public abstract class Entity
    {
        public abstract string GetDescription();

        public int Hp { get; protected set; }

        public int MaxHp { get; }

        private readonly Attack[] attacks;

        public virtual Attack[] GetAvailableAttacks()
        {
            return this.attacks;
        }

        public virtual void Damage(int amount)
        {
            this.Hp = Math.Max(0, this.Hp - amount);
        }

        public string GetName()
        {
            return "The " + this.GetType().Name;
        }

        public bool IsDead()
        {
            return this.Hp <= 0;
        }

        protected Entity(Attack[] attacks, int maxHp)
        {
            this.attacks = attacks;
            this.MaxHp = maxHp;
            this.Hp = maxHp;
        }
    }
}