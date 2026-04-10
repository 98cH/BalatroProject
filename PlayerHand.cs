using System.Collections.Generic;
using System.Linq;

namespace BalatroProject
{
    public class PlayerHand
    {
        private List<ICard> hand;
        private int MaxCards;
        private List<int> SelectedIndexes;

        public PlayerHand(int maxCards)
        {
            hand = new List<ICard>();
            MaxCards = maxCards;
            SelectedIndexes = new List<int>();
        }

        public List<ICard> CardsInHand => hand;
        public List<int> SelectedCards => SelectedIndexes;

        public void DrawFromDeck(Deck deck)
        {
            CardsInHand.Clear(); 

            for (int i = 0; i < 5; i++)
            {
                var card = deck.TakeCard();
                if (card != null)
                    CardsInHand.Add(card);
            }
        }

        public void SelectCard(int index)
        {
            if (index < 0 || index >= hand.Count) return;

            if (SelectedIndexes.Contains(index))
                SelectedIndexes.Remove(index);
            else
                SelectedIndexes.Add(index);
        }

        public void DeselectCard(int index)
        {
            SelectedIndexes.Remove(index);
        }

        public List<ICard> GetSelected()
        {
            return hand.Where((c, i) => SelectedIndexes.Contains(i)).ToList();
        }

        public void RemoveSelected()
        {
            hand = hand.Where((c, i) => !SelectedIndexes.Contains(i)).ToList();
            SelectedIndexes.Clear();
        }
    }
}