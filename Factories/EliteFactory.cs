namespace ProjektKD.Factories
{
    using ProjektKD.Entities.Monsters;

    public class EliteFactory : MonsterFactory<Elite>
    {
        protected override Elite CreateMonster()
        {
            return new Elite(13, R.Next(80, 100));
        }
    }
}