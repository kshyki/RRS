using System.Collections.Generic;

namespace RandomizedRewardSystem.Models
{
    public class Board
    {
        public const int Rows = 6;
        public const int Columns = 5;

        public List<(int dr, int dc)> directions = new()
        {
            (-1, 0),
            (1, 0),
            (0, -1),
            (0, 1)
        };
        
        public Symbol?[,] Grid;
        public bool[,] visited;
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

        private void Search(int r, int c, SymbolType targetType, bool[,] visited, List<(int r, int c)> group)
        {

            group.Add((r, c));
            visited[r, c] = true;

            foreach(var (dr, dc) in directions)
            {
                int nr = r + dr;
                int nc = c + dc;

                if((nr >= 0) && (nr < Rows))
                {
                    if((nc >= 0) && (nc < Columns))
                    {
                        if(!visited[nr, nc])
                        {
                            if(Grid[nr, nc].Type == targetType)
                            {
                                Search(nr, nc, targetType, visited, group);
                            }

                        }
                    }
                }
            }
        }
        public List<List<(int r, int c)>> FindWinningGroups()
        {
            var allGroups = new List<List<(int r, int c)>>();

            bool [,] visited = new bool[Rows, Columns];

            for(int r = 0; r < Rows; r++)
            {
                for(int c = 0; c < Columns; c++)
                {
                    if (!visited[r, c])
                    {
                        var CurrentGroup = new List<(int r, int c)>();
                        
                        if(Grid[r, c] != null)
                        { 
                            Search(r, c, Grid[r, c].Type, visited, CurrentGroup);   
                        }

                        if(CurrentGroup.Count >= 8)
                        {
                            allGroups.Add(CurrentGroup);
                        }
                    }
                }
            }

            return allGroups;
        }

        public void RemoveGroups(List<List<(int r, int c)>> groups)
        {
            foreach (var group in groups)
            {
                foreach (var (r, c) in group)
                {
                    Grid[r, c] = null;
                }
            }
        }
    }
}