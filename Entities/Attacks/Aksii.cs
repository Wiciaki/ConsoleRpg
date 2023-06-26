namespace ProjektKD.Entities.Attacks
{
    public class Aksii : Sign
    {
        public Aksii() : base(0, 0, 0, 0, "You skipped a round", "Aksii: Skips the round")
        {

        }

        public override string SelectedSign { get; } = "Aksii";
    }
}