using System.Collections.Generic;

namespace BalatroProject
{
    public class GameEngine
    {
        private Model model;

        public int TotalScore { get; private set; }
        public int Rounds { get; private set; }
        public int MaxRounds { get; private set; } = 5;

        public GameEngine(Model model)
        {
            this.model = model;
            TotalScore = 0;
            Rounds = 0;
        }

        public (int score, HandType handType) PlayRound()
        {
            var selected = model.PlayerHand.GetSelected();

            if (selected.Count == 0)
                return (0, HandType.None);

            var evaluator = new HandEvaluator();
            var result = evaluator.Evaluate(selected);

            var score = new ScoreCalculator().CalculateScore(selected, result.handType);

            TotalScore += score;
            Rounds++;

            model.PlayerHand.RemoveSelected();
            model.PlayerHand.DrawFromDeck(model.Deck);

            return (score, result.handType);
        }

        public bool IsGameOver()
        {
            return Rounds >= MaxRounds;
        }

        public void Reset()
        {
            TotalScore = 0;
            Rounds = 0;

            model.Deck.Reset();
            model.Deck.Shuffle();

            model.PlayerHand = new PlayerHand(5);
            model.PlayerHand.DrawFromDeck(model.Deck);
        }

        public Model GetModel()
        {
            return model;
        }
    }
}