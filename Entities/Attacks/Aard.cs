namespace ProjektKD.Entities.Attacks
{
    public class Aard : Sign
    {
        public Aard(int damage) : base(damage, damage, 0, -damage, $"You've done {damage} damage to both yourself and the enemy", "Aard: Does massive damage to both yourself and the enemy")
        {

        }

        public override string SelectedSign { get; } = "Aard";
    }
}