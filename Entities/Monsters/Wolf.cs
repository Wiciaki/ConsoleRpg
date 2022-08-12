namespace ProjektKD.Entities.Monsters
{
    public class Wolf : Monster
    {
        public Wolf(int attack, int maxHp) : base(attack, maxHp, false)
        {

        }

        public override string GetDescription()
        {
            return "A common enemy\n\t8 attack and between 40-80 HP";
        }
    }
}