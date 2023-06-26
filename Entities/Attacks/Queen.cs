namespace ProjektKD.Entities.Attacks
{
    public class Queen : Sign
    {
        public Queen(int healed) : base(0, 0, 0, healed, $"You have restored {healed}HP", $"Queen: Heal yourself ({healed}HP)")
        {

        }

        public override string SelectedSign { get; } = "Queen";
    }
}