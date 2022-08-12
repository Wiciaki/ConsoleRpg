namespace ProjektKD.Gui
{
    using ProjektKD.Entities.Heroes;

    public abstract class GameGui
    {
        public abstract int ShowSelection(string title, string message, string[] options, Hero hero = null);
    }
}