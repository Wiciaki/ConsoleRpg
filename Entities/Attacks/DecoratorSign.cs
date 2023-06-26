namespace ProjektKD.Entities.Attacks
{
    public abstract class DecoratorSign<T> where T : ISign
    {
        protected DecoratorSign(T t)
        { 
            this.CastedSign = t;
        }

        T CastedSign { get; }

        public abstract void SignCast();
    }
}