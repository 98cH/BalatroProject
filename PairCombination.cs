using System.Collections.Generic;
using System.Linq;

namespace BalatroProject
{
    public class PairCombination : ICombination
    {
        public string Name => "Pair";

        public bool IsMatch(List<ICard> cards)
        {
            return cards.GroupBy(c => c.Value).Any(g => g.Count() == 2);
        }
    }
}