namespace ProjektKD.Entities.Attacks
{
    public class DecoratorAksii : DecoratorSign<Aksii>
    {
        public DecoratorAksii(Aksii t) : base(t)
        {
        }

        public override void SignCast()
        {

        }

        public int ReduceStamina()
        {
            return 0;
        }
    }
}