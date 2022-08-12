namespace ProjektKD.Factories
{
    using ProjektKD.Entities.Monsters;

    public class DragonFactory : MonsterFactory<Dragon>
    {
        protected override Dragon CreateMonster()
        {
            return new Dragon(12, R.Next(80, 120));
        }
    }
}
