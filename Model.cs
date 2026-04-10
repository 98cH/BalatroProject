namespace BalatroProject
{
    public class Model
    {
        public Deck Deck { get; }
        public PlayerHand PlayerHand { get; set;  }

        public Model(Deck deck, PlayerHand hand)
        {
            Deck = deck;
            PlayerHand = hand;
        }
    }
}