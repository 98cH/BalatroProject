namespace BalatroProject
{
    public class GlassCard : CardBase
    {
        public GlassCard(CardValue value, Suit suit) : base(value, suit)
        {
        }

        public int GetMultiplier()
        {
            return 2;
        }

        public override string GetDisplay()
        {
            return base.GetDisplay() + " (Glass)";
        }
    }
}