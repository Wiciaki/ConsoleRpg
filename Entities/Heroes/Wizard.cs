namespace ProjektKD.Entities.Heroes
{
    using System.Collections.Generic;

    public class Wizard : Hero
    {
        private Memento m;

        public Wizard(int attack, int maxHp, int maxMana) : base(attack, maxHp, maxMana)
        {

        }

        public override string[] GetAttackOptions()
        {
            var options = new List<string> { "Lightning bolt" };

            if (Mana >= 8)
            {
                options.Add("Fireball");

                if (Mana >= 20)
                {
                    options.Add("Rewind time + fireball");
                }
            }

            return options.ToArray();
        }

        public override string GetDescription()
        {
            return "The wizard is very wise and has access to two powerful spells - 'fireball' and 'rewind time'\n\tYou also start combat 4 hexes away from the enemy\n\n\tPros: High spell damage and many combat options\n\tCons: Lowest base stats";
        }

        public override void NextAttack()
        {
            base.NextAttack();

            this.attacks.Add(60);
            this.attacks.Add(60);

            this.descriptions.Add("You burned your enemy, dealing 60 dmg");
            this.descriptions.Add("You've restored the time and feeling as strong as before\n\n\t" + this.descriptions[1]);
            
            m = this.ToMemento();
        }

        public override void UseAttack(int index)
        {
            if (index == 1)
            {
                this.Mana -= 8;
            }
            else if (index == 2)
            {
                this.Mana -= 20;
                Restore(m);
            }
        }

        private void Restore(Memento memento)
        {
            this.Hp = memento.Hp;
            this.Mana = memento.Mana;
        }

        private Memento ToMemento()
        {
            return new Memento
            {
                Hp = this.Hp,
                Mana = this.Mana
            };
        }

        private class Memento
        {
            public int Hp { get; set; }

            public int Mana { get; set; }
        }
    }
}