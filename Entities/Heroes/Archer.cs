namespace ProjektKD.Entities.Heroes
{
    using System.Collections.Generic;

    public class Archer : Hero
    {
        public Archer(int attack, int maxHp, int maxMana) : base(attack, maxHp, maxMana)
        {

        }

        public override string GetDescription()
        {
            return "The Archer has a bow which lets him take down his prey from impressive distance\n\tStart your combat 4 hexes away from the enemy\n\n\tPros:\n\t- Starts combat far away from the enemy\n\t- Deals extra damage based on distance\n\n\tCons:\n\t- Single attack option\n\t- Ineffective in close combat";
        }

        public override string[] GetAttackOptions()
        {
            var options = new List<string> { $"Shoot an enemy ({this.attacks[0]} dmg)" };

            if (this.Mana >= 10)
            {
                options.Add($"Launch a hail of arrows ({this.attacks[1]} dmg, 10 mana)");
            }

            return options.ToArray();
        }

        public override void NextAttack()
        {
            base.NextAttack();

            this.attacks.Add(25);
            this.descriptions.Add($"Hail of arrows landed, dealing {this.attacks[1]} dmg");
        }

        public override void UseAttack(int index)
        {
            if (index == 1)
            {
                this.Mana -= 10;
            }
        }
    }
}