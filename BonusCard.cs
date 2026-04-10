namespace BalatroProject
{
    public class BonusCard : CardBase
    {
        public BonusCard(CardValue value, Suit suit) : base(value, suit)
        {
        }

        public override int GetScore()
        {
            return base.GetScore() + 10;
        }

        public override string GetDisplay()
        {
            return base.GetDisplay() + " (Bonus)";
        }
    }
}