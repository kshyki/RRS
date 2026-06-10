using System.Collections.Generic;

namespace RandomizedRewardSystem.Models
{
    public class GameSession
    {
        public Board board = new Board();
        private const int MAX_ROUNDS = 15;
        public int currentRound;
        public long totalScore;
        public int gameMultiplier;

        public GameSession()
        {
            board.InitializeBoard();
            currentRound = 0;
            totalScore = 0;
            gameMultiplier = 1;
        }

        public void PlayRound() // method that runs one round of the game
        {
            long roundWin = 0;
            int accumulatedMultiplier = 0;
            HashSet<Symbol> usedMultipliers = new();

            if (currentRound >= MAX_ROUNDS) return;

            currentRound++;
            board.InitializeBoard();
            bool isWin;

            do
            {
                var winingGroups = board.FindWinningGroups();

                isWin = winingGroups.Count > 0;

                if (!isWin) break;
                foreach (var group in winingGroups)
                {
                    foreach (var cell in group)
                    {
                        Symbol symbol = board.Grid[cell.r, cell.c];

                        if (!symbol.IsMultiplier)
                        {
                            roundWin += symbol.Value;
                        }
                    }
                }

                for (int r = 0; r < 6; r++)
                {
                    for (int c = 0; c < 5; c++)
                    {
                        Symbol symbol = board.Grid[r, c];

                        if (symbol.IsMultiplier && !usedMultipliers.Contains(symbol))
                        {
                            accumulatedMultiplier += 2;
                            usedMultipliers.Add(symbol); 
                        }
                    }
                }

                board.RemoveGroups(winingGroups);
                board.ApplyGravity();
                board.RefillBoard();

            } while (isWin);

            if(gameMultiplier == 1 && accumulatedMultiplier != 0) gameMultiplier = accumulatedMultiplier;
            else if(gameMultiplier != 1) gameMultiplier += accumulatedMultiplier;

            roundWin *= gameMultiplier;
            totalScore += roundWin;
        }
    }
}