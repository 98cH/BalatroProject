using System.Collections.Generic;

namespace BalatroProject
{
    public class ScoreCalculator
    {
        public int CalculateScore(List<ICard> cards, HandType handType)
        {
            int baseScore = 0;
            int multiplier = 1;

            foreach (var card in cards)
            {
                baseScore += card.GetScore();

                if (card is ExtraCard extra)
                {
                    baseScore += extra.GetExtraScore(cards);
                }

                if (card is GlassCard glass)
                {
                    multiplier *= glass.GetMultiplier();
                }
            }

            int bonus = handType switch
            {
                HandType.HighCard => 0,
                HandType.Pair => 10,
                HandType.TwoPair => 20,
                HandType.ThreeOfAKind => 30,
                _ => 0
            };

            return (baseScore + bonus) * multiplier;
        }
    }
}