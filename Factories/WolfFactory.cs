namespace ProjektKD.Factories
{
    using ProjektKD.Entities.Monsters;

    public class WolfFactory : MonsterFactory<Wolf>
    {
        protected override Wolf CreateMonster()
        {
            return new Wolf(8, R.Next(40, 80));
        }
    }
}