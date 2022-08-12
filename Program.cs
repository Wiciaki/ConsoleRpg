namespace ProjektKD
{
    using ProjektKD.Entities.Heroes;
    using ProjektKD.Entities.Monsters;
    using ProjektKD.Factories;
    using ProjektKD.Gui;
    using ProjektKD.Navigation;

    public static class Program
    {
        private static void Main(string[] args)
        {
            INavigation gameWindow = new Game(new ConsoleGui())
            {
                Heroes = new Hero[] { new Knight(22, 300, 0), new Archer(18, 220, 20), new Wizard(15, 180, 40) },
                Factories = new IMonsterFactory[] { new WolfFactory(), new WerewolfFactory(), new EliteFactory(), new DragonFactory() },
                Boss = new Boss(20, 150)
            };

            gameWindow.Show();
        }
    }
}