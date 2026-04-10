using System;
using System.Linq;

namespace BalatroProject
{
    public class ViewModel
    {
        private GameEngine gameEngine;
        private Model model;

        public ViewModel(Model model)
        {
            this.model = model;
            gameEngine = new GameEngine(model);
        }

        public void Run()
        {
            while (true)
            {
                StartGame();

                while (!gameEngine.IsGameOver())
                {
                    RenderUI();
                    HandleInput();
                }

                ShowGameOver();

                var input = Console.ReadLine();

                if (input.ToLower() == "r")
                {
                    ResetGame();
                }
                else
                {
                    break;
                }
            }
        }

        private void StartGame()
        {
            model.Deck.Reset();
            model.PlayerHand.DrawFromDeck(model.Deck);
        }

        private void ResetGame()
        {
            gameEngine.Reset();
            model = gameEngine.GetModel();
            StartGame();
        }

        private void ShowGameOver()
        {
            Console.Clear();
            Console.WriteLine("GAME OVER");
            Console.WriteLine($"Final Score: {gameEngine.TotalScore}");
            Console.WriteLine("Druk R + Enter om opnieuw te starten");
        }

        private void RenderUI()
        {
            Console.Clear();

            var hand = model.PlayerHand.CardsInHand.ToList();
            var selected = model.PlayerHand.SelectedCards;

            Console.WriteLine($"Deck: {model.Deck.CardsRemainingCount}/{model.Deck.TotalCardCount}");
            Console.WriteLine($"Total Score: {gameEngine.TotalScore}");
            Console.WriteLine($"Round: {gameEngine.Rounds}/{gameEngine.MaxRounds}");

            Console.WriteLine("Selecteer kaarten (1-5)");
            Console.WriteLine("Typ opnieuw om te deselecteren");
            Console.WriteLine("Druk S + Enter om te spelen");

            for (int i = 0; i < hand.Count; i++)
            {
                string mark = selected.Contains(i) ? "[x]" : "[ ]";
                Console.WriteLine($"{i + 1}: {mark} {hand[i].GetDisplay()}");
            }
        }

        private void HandleInput()
        {
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
                return;

            if (input.ToLower() == "s")
            {
                var result = gameEngine.PlayRound();

                Console.WriteLine($"Hand: {result.handType}");
                Console.WriteLine($"Score: {result.score}");
                Console.WriteLine($"Total Score: {gameEngine.TotalScore}");
                Console.WriteLine("Druk op Enter...");
                Console.ReadLine();
                return;
            }

            foreach (char c in input)
            {
                if (int.TryParse(c.ToString(), out int index))
                {
                    index--;

                    if (model.PlayerHand.SelectedCards.Contains(index))
                        model.PlayerHand.DeselectCard(index);
                    else
                        model.PlayerHand.SelectCard(index);
                }
            }
        }
    }
}
