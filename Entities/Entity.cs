namespace ProjektKD.Entities
{
    using System;
    using System.Collections.Generic;

    public abstract class Entity
    {
        public abstract string GetDescription();

        protected readonly Random R;

        public int Attack { get; }

        public int MaxHp { get; }

        public int Hp { get; protected set; }

        protected readonly List<int> attacks;

        protected readonly List<string> descriptions;

        public int GetAttackDamage(int i)
        {
            return attacks[i];
        }

        public string GetAttackDescription(int i)
        {
            return descriptions[i];
        }

        public virtual void NextAttack()
        {
            attacks.Clear();
            descriptions.Clear();

            attacks.Add(Attack - 2 + R.Next(0, 4));
            descriptions.Add(GetName() + " attacks, dealing " + attacks[0] + " damage");
        }

        public virtual void Damage(int amount)
        {
            this.Hp = Math.Max(0, Hp - amount);
        }

        public string GetName()
        {
            return "The " + this.GetType().Name;
        }

        public bool IsDead()
        {
            return Hp <= 0;
        }

        protected Entity(int attack, int maxHp)
        {
            this.Attack = attack;
            this.MaxHp = maxHp;
            this.Hp = maxHp;
            this.R = new Random();
            this.attacks = new List<int>();
            this.descriptions = new List<string>();
        }
    }
}