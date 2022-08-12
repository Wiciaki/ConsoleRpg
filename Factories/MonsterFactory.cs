namespace ProjektKD.Factories
{
    using System;

    using ProjektKD.Entities.Monsters;

    public abstract class MonsterFactory<T> : IMonsterFactory where T : Monster
    {
        protected abstract T CreateMonster();

        protected readonly Random R = new Random();

        Monster IMonsterFactory.CreateMonster()
        {
            return this.CreateMonster();
        }
    }
}