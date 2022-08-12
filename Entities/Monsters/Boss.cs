namespace ProjektKD.Entities.Monsters
{
    public class Boss : Monster
    {
        public override string GetDescription()
        {
            return "Has incredibly powerful attacks and can cast spells. You will encounter him at the very end of the game\n\t150 health, 20 attack, ressurection ability, can retaliate";
        }

        public bool HasRessurected { get; private set; }

        public Boss(int attack, int maxHp) : base(attack, maxHp, true)
        {

        }

        public void Reset()
        {
            this.Hp = this.MaxHp;
        }

        public override void Damage(int amount)
        {
            base.Damage(amount);

            if (IsDead() && !HasRessurected)
            {
                this.HasRessurected = true;
                this.Hp = MaxHp;
                this.descriptions[0] = "The Boss has ressurected!\n\n\t" + this.descriptions[0];
            }
        }
    }
}