using System.Collections.Generic;
using System.Linq;

namespace BalatroProject
{
    public class ExtraCard : CardBase
    {
        public ExtraCard(CardValue value, Suit suit) : base(value, suit)
        {
        }

        public int GetExtraScore(List<ICard> cards)
        {
            int sameValueCount = cards.Count(c => c.Value == this.Value);
            return (sameValueCount - 1) * 2;
        }

        public override string GetDisplay()
        {
            return base.GetDisplay() + " (Extra)";
        }
    }
}