namespace ProjektKD.Entities.Attacks
{
    public class Igni : Sign
    {
        public Igni(int damage) : base(damage, damage, 0, 0, $"Igni: did {damage} damage", $"Igni: {damage} fire damage")
        {

        }

        public override string SelectedSign { get; } = "Igni";
    }
}