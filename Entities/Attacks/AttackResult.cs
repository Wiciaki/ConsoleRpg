namespace ProjektKD.Entities.Attacks
{
    public class AttackResult
    {
        public AttackResult(int damage, int lostMana, int healed, string message)
        {
            this.Damage = damage;
            this.Message = message;
            this.LostMana = lostMana;
            this.Healed = healed;
        }

        public int Damage { get; }

        public int LostMana { get; }

        public int Healed { get; }

        public string Message { get; }
    }
}