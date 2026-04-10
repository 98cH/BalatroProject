namespace BalatroProject
{
    public interface ICard
    {
        CardValue Value { get; }
        Suit Suit { get; }
        int GetScore();
        string GetDisplay();
    }
}