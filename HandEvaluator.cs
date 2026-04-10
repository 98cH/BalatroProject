using System.Collections.Generic;
using System.Linq;

namespace BalatroProject
{
    public class HandEvaluator
    {
        public (HandType handType, List<ICard> usedCards) Evaluate(List<ICard> cards)
        {
            if (cards == null || cards.Count == 0)
                return (HandType.None, new List<ICard>());

            var values = cards.GroupBy(c => c.Value).ToList();
            var suits = cards.Where(c => c.Suit != Suit.None).GroupBy(c => c.Suit).ToList();

            int wildCount = cards.Count(c => c is WildCard);

            if (IsFlush(cards, wildCount))
                return (HandType.Flush, cards);

            if (values.Any(g => g.Count() + wildCount >= 3))
                return (HandType.ThreeOfAKind, cards);

            if (values.Count(g => g.Count() >= 2) >= 2 ||
                (values.Count(g => g.Count() >= 2) == 1 && wildCount >= 1))
                return (HandType.TwoPair, cards);

            if (values.Any(g => g.Count() + wildCount >= 2))
                return (HandType.Pair, cards);

            return (HandType.HighCard, cards);
        }

        private bool IsFlush(List<ICard> cards, int wildCount)
        {
            var suitGroups = cards
                .Where(c => c.Suit != Suit.None)
                .GroupBy(c => c.Suit)
                .Select(g => g.Count())
                .ToList();

            if (!suitGroups.Any())
                return false;

            int maxSameSuit = suitGroups.Max();

            return maxSameSuit + wildCount >= 5;
        }
    }
}