namespace ProjektKD.Entities.Heroes
{
    public class Knight : Hero
    {
        public Knight(int attack, int maxHp, int maxMana) : base(attack, maxHp, maxMana)
        {

        }

        public override string[] GetAttackOptions()
        {
            return new string[] { "Use normal attack", "Charge powerful attack (40% chance to miss)" };
        }

        public override string GetDescription()
        {
            return "The Knight is a heavily armoured unit and he does not fear any enemy\n\tYou can use a normal attack, or charge a powerful strike with double the damage but a 40% chance to miss\n\n\tPros: Highest base stats\n\tCons: No ranged attack";
        }

        public override void NextAttack()
        {
            base.NextAttack();

            var miss = R.Next(0, 100) > 60;
            
            if (miss)
            {
                this.attacks.Add(0);
                this.descriptions.Add("You missed!");
            }
            else
            {
                this.attacks.Add(this.attacks[0] * 2);
                this.descriptions.Add($"Ouch! This really hurt. You did {this.attacks[1]} dmg");
            }
        }
    }
}