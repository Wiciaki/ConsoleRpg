namespace ProjektKD.Entities.Attacks
{
    public class BasicAttack : Attack
    {
        public BasicAttack(int attack, string message, string description = "") : base(attack - 2, attack + 2, 0, 0, message, description)
        {

        }
    }
}