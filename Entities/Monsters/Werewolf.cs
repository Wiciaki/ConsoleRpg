namespace ProjektKD.Entities.Monsters
{
    public class Werewolf : Monster
    {
        public Werewolf(int attack, int maxHp) : base(attack, maxHp, true)
        {

        }

        public override string GetDescription()
        {
            return "A stronger ordinary enemy. Can retaliate\n\t9 attack, 80-100 HP";
        }
    }
}