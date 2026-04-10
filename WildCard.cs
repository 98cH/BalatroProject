namespace BalatroProject
{
    public class WildCard : CardBase
    {
        public WildCard(CardValue value) : base(value, Suit.None)
        {
        }

        public override string GetDisplay()
        {
            return base.GetDisplay() + " (Wild)";
        }
    }
}