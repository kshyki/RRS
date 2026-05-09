namespace RandomizedRewardSystem.Models
{
    public class Board
    {
        public const int Rows = 6;
        public const int Columns = 5;

        public Symbol[,] Grid;

        public Board()
        {
            Grid = new Symbol[Rows, Columns];
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            for(int r = 0; r < Rows; r++)
            {
                for(int c = 0; c < Columns; c++)
                {
                    Grid[c,r] = SymbolFactory.GetRandomSymbol();
                }
            }
        }

        public void SetSymbol(int row, int col, Symbol symbol)
        {
            Grid[row,col] = symbol;
        }
    }
}