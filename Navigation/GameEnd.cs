namespace ProjektKD.Navigation
{
    public class GameEnd : INavigation
    {
        private readonly Game game;
        private readonly bool win;

        public GameEnd(Game game, bool win)
        {
            this.game = game;
            this.win = win;
        }

        public void Show()
        {
            string title, message;
            var options = new string[] { "Play again", "Leave game" };

            if (win)
            {
                title = "Congratulations!!!!";
                message = "You are an epic hero";
            }
            else
            {
                title = "Ouch. You are dead.";
                message = "Next time you will make it!";
            }

            if (game.Gui.ShowSelection(title, message, options) == 0)
            {
                game.Show();
            }
        }
    }
}