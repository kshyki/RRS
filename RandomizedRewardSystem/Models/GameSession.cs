namespace RandomizedRewardSystem.Models
{
    public class GameSession
    {
        public Board board = new Board();
        private const int MAX_ROUNDS = 15;
        public int currentRound;
        public long totalScore;
        public int roundMultiplier;

        public GameSession()
        {
            board.InitializeBoard();
            currentRound = 0;
            totalScore = 0;
            roundMultiplier = 1;
        }

        public void PlayRound()
        {
            if (currentRound >= MAX_ROUNDS) return;

            currentRound++;
            roundMultiplier = 1;
            board.InitializeBoard();
            bool isWin;
            do
            {
                var winingGroups = board.FindWinningGroups();
                isWin = winingGroups.Count > 0;

                if (isWin)
                {
                    foreach(var group in winingGroups)
                    {
                        Symbol currentSymbol = board.Grid[group[0].r, group[0].c];

                        if (currentSymbol.IsMultiplier)
                        {
                            roundMultiplier += 2;
                        } else
                        {
                            totalScore += currentSymbol.Value * group.Count * roundMultiplier;
                        }

                    }

                    board.RemoveGroups(winingGroups);
                    board.ApplyGravity();
                    board.RefillBoard();
                }
            } 
            while (isWin);
        }

    }
}