namespace BalatroProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var deck = new Deck();
            deck.Shuffle();

            var hand = new PlayerHand(5);
            hand.DrawFromDeck(deck);

            var model = new Model(deck, hand);
            var viewModel = new ViewModel(model);

            viewModel.Run();
        }
    }
}