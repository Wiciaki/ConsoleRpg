namespace ProjektKD.Entities.Attacks
{
    public class DecoratorQueen : DecoratorSign<Queen>
    {
        public DecoratorQueen(Queen t) : base(t)
        {

        }

        public override void SignCast()
        {

        }

        public bool FullHealing()
        {
            return false;
        }
    }
}