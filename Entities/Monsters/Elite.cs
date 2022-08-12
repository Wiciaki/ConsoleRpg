namespace ProjektKD.Entities.Monsters
{
    public class Elite : Monster
    {
        public Elite(int attack, int maxHp) : base(attack, maxHp, true)
        {

        }

        public override string GetDescription()
        {
            return "Elite. A stronger enemy, has 80-100 HP and 13 attack but no special abilities\n\tCan retaliate";
        }
    }
}