using System.Collections.Generic;

namespace BalatroProject
{
    public interface ICombination
    {
        bool IsMatch(List<ICard> cards);
        string Name { get; }
    }
}