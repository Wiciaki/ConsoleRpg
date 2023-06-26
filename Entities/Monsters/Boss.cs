namespace ProjektKD.Entities.Monsters
{
    public class Boss : Monster
    {
        public override string GetDescription()
        {
            return "Has incredibly powerful attacks and can cast spells. You will encounter him at the very end of the game\n\t150 health, 20 attack, ressurection ability, can retaliate";
        }

        public bool HasRessurected { get; private set; }

        private bool hasDisplayed;

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
            }
        }

        public override string ExtraMessage()
        {
            if (!this.HasRessurected || this.hasDisplayed)
            {
                return base.ExtraMessage();    
            }

            this.hasDisplayed = true;
            return "The Boss has resurrected!\n\n\t";
        }
    }
}