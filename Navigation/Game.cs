namespace ProjektKD.Navigation
{
    using System.Collections.Generic;
    using System.Linq;

    using ProjektKD.Entities.Heroes;
    using ProjektKD.Entities.Monsters;
    using ProjektKD.Factories;
    using ProjektKD.Gui;

    public class Game : INavigation
    {
        public GameGui Gui { get; }

        public Hero Hero { get; private set; }

        public Hero[] Heroes { get; set; }

        public Boss Boss { get; set; }

        public IMonsterFactory[] Factories { get; set; }

        public Game(GameGui gui)
        {
            this.Gui = gui;
        }

        public void Show()
        {
            var options = new string[] { "Play as Knight", "Play as Archer", "Play as Wizard", "Browse heroes", "Browse enemies", "Browse boss", "Leave game" };

            if (Hero != null)
            {
                round = 0;

                Hero.Reset();
                Boss.Reset();
            }

            switch (Gui.ShowSelection("Welcome to the journey of your life!", "Who do you want to play as?\n\tBrowse the options before you start a game", options))
            {
                case 0:
                    Hero = Heroes.OfType<Knight>().First();
                    GameWindow();
                    break;
                case 1:
                    Hero = Heroes.OfType<Archer>().First();
                    GameWindow();
                    break;
                case 2:
                    Hero = Heroes.OfType<Wizard>().First();
                    GameWindow();
                    break;
                case 3:
                    var browser1 = new EntityBrowser(this, Heroes);
                    browser1.Show();
                    break;
                case 4:
                    var entities = Factories.Select(f => f.CreateMonster()).ToArray();
                    var browser2 = new EntityBrowser(this, entities);
                    browser2.Show();
                    break;
                case 5:
                    var browser3 = new EntityBrowser(this, Boss);
                    browser3.Show();
                    break;
                case 6:
                    break;
            }
        }

        private void GameWindow(string message = null)
        {
            var title = "What's your next move?";
            var monsters = GetMonsters();
            var options = monsters.Select(m => "Attack " + m.GetName()).ToList();
            
            if (Hero.RemainingWellTimes > 0)
            {
                options.Add($"Use well (remaining times: {Hero.RemainingWellTimes}/3) - restore 50% HP and 100% Mana");
            }

            var index = Gui.ShowSelection(title, message, options.ToArray(), Hero);

            if (index == monsters.Count)
            {
                Hero.UseWell();
                GameWindow("Using the well makes you fell stronger than ever");
            }
            else
            {
                FightWindow(monsters[index]);
            }
        }

        private int round;

        private List<Monster> GetMonsters()
        {
            if (round > 4)
            {
                return new List<Monster> { Boss };
            }

            return this.Factories.Skip(this.round / 2).Take(3).Select(factory => factory.CreateMonster()).ToList();
        }

        private void FightWindow(Monster monster, string message = null)
        {
            Hero.NextAttack();
            monster.NextAttack();

            var title = "The beast looks at you and salivates...";
            var index = Gui.ShowSelection(title, message, Hero.GetAttackOptions(), Hero);
            
            Hero.UseAttack(index);
            monster.Damage(Hero.GetAttackDamage(index));

            if (monster.IsDead())
            {
                if (monster == Boss)
                {
                    var end = new GameEnd(this, true);
                    end.Show();
                }
                else
                {
                    this.round++;
                    GameWindow("That was an epic battle! Keep going...");
                }
            }
            else
            {
                Hero.Damage(monster.GetAttackDamage(0));

                if (Hero.IsDead())
                {
                    var end = new GameEnd(this, false);
                    end.Show();
                    return;
                }

                message = Hero.GetAttackDescription(index) + "\n\n\t" + monster.GetAttackDescription(0);
                message += $"\n\n\t{monster.GetName()} has {monster.Hp}HP left";

                FightWindow(monster, message);
            }
        }
    }
}