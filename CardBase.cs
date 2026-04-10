namespace BalatroProject
{
    public abstract class CardBase : ICard
    {
        public CardValue Value { get; protected set; }
        public Suit Suit { get; protected set; }

        public CardBase(CardValue value, Suit suit)
        {
            Value = value;
            Suit = suit;
        }

        public virtual int GetScore()
        {
            return (int)Value;
        }

        public virtual string GetDisplay()
        {
            return $"{Value} {Suit}";
        }
    }
}