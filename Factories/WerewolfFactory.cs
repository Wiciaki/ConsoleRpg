namespace ProjektKD.Factories
{
    using ProjektKD.Entities.Monsters;

    public class WerewolfFactory : MonsterFactory<Werewolf>
    {
        protected override Werewolf CreateMonster()
        {
            return new Werewolf(9, R.Next(80, 100));
        }
    }
}