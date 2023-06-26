namespace ProjektKD.Entities.Attacks
{
    public class DecoratorAard : DecoratorSign<Aard>
    {
        public DecoratorAard(Aard t) : base(t)
        {

        }

        public override void SignCast()
        {

        }

        public int StaminaBoost()
        {
            return 0;
        }
    }
}