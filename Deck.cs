using System;
using System.Collections.Generic;
using System.Linq;

namespace BalatroProject
{
    public class Deck
    {
        private List<CardBase> cards;
        private Random random;

        public int CardsRemainingCount => cards.Count;
        public int TotalCardCount { get; private set; }

        public Deck()
        {
            random = new Random();
            cards = new List<CardBase>();
            GenerateDeck();
        }

        private void GenerateDeck()
        {
            cards.Clear();

            var suits = Enum.GetValues(typeof(Suit)).Cast<Suit>();
            var values = Enum.GetValues(typeof(CardValue)).Cast<CardValue>();

            foreach (var suit in suits)
            {
                if (suit == Suit.None) continue;

                foreach (var value in values)
                {
                    cards.Add(CreateRandomCard(value, suit));
                }
            }

            TotalCardCount = cards.Count;
        }
        private CardBase CreateRandomCard(CardValue value, Suit suit)
        {
            int roll = random.Next(100);

            if (roll < 2)
                return new WildCard(value);
            else if (roll < 5)
                return new GlassCard(value, suit);
            else if (roll < 8)
                return new BonusCard(value, suit);
            else if (roll < 12)
                return new ExtraCard(value, suit);
            else
                return new Card(value, suit);
        }

        public void Shuffle()
        {
            cards = cards.OrderBy(x => random.Next()).ToList();
        }

        public CardBase TakeCard()
        {
            if (cards.Count == 0)
                return null;

            var card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public void Reset()
        {
            GenerateDeck();
            Shuffle();
        }
    }
}

