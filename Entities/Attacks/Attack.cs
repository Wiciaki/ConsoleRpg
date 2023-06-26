namespace ProjektKD.Entities.Attacks
{
    using System;

    public class Attack
    {
        public int MinDamage { get; }

        public int MaxDamage { get; }

        public int ManaCost { get; }

        public int SelfHeal { get; }

        public string Message { get; }

        public string Description { get; }

        protected Random Random { get; }

        public Attack(int minDamage, int maxDamage, int manaCost, int selfHeal, string message, string description)
        {
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.ManaCost = manaCost;
            this.SelfHeal = selfHeal;
            this.Message = message;
            this.Description = description;
            this.Random = new Random();
        }

        public virtual bool IsAvailable(int availableMana)
        {
            return this.ManaCost <= availableMana;
        }

        public virtual AttackResult Execute()
        {
            var damage = this.Random.Next(this.MinDamage, this.MaxDamage);

            return new AttackResult(damage, this.ManaCost, this.SelfHeal, string.Format(this.Message, damage));
        }
    }
}