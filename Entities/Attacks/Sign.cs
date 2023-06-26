namespace ProjektKD.Entities.Attacks
{
    using System.Collections.Generic;

    public abstract class Sign : Attack, ISign
    {
        public abstract string SelectedSign { get; }

        public void SignCast()
        {

        }

        protected Sign(int minDamage, int maxDamage, int manaCost, int healed, string message, string description) : base(minDamage, maxDamage, manaCost, healed, message, description)
        {

        }

        public static readonly List<Sign> SignList = new List<Sign> {
            new Queen(18),
            new Aksii(),
            new Aard(30),
            new Igni(21)
        };
    }
}