using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISE_ONE
{
    class Astar : SolveMethod
    {
        private SortedList<int, Board> openSet;
        private List<Board> closedSet;

        private string heuristic;

        public Astar()
        {
            openSet = new SortedList<int, Board>();
            closedSet = new List<Board>();
            heuristic = "manh";
        }

        public override void Solve(int[,] puzzleToSolve, int puzzleSize, string arg)
        {
            if (arg != null)
                heuristic = arg;

            Board board = new Board(puzzleSize, puzzleToSolve);
            openSet.Add(f(board), board);

            while(openSet.Count > 0)
            {
                
            }            
        }

        private int f(Board b)
        {
            int g = b.previousSteps.Length;

            int h;

            if(heuristic == "manh")
            {
                h = Manhatan(b);
            }
            else
            {
                h = Hamming(b);
            }

            return g + h;
        }

        private int Manhatan(Board b)
        {
            int distance = 0;
            for (int i = 0; i < b.currentBoard.GetLength(0); i++)
            {
                for(int j = 0; j < b.currentBoard.GetLength(1); j++)
                {
                    int value = b.currentBoard[i, j];
                    if(value > 0)
                    {
                        value--;
                        int x = Math.Abs(j - (value % b.currentBoard.GetLength(1)));
                        int y = Math.Abs(i - (value / b.currentBoard.GetLength(1)));

                        distance += x + y;
                    }
                }
            }
            return distance;
        }

        private int Hamming(Board b)
        {
            int distance = 0;
            int value = 1;
            for(int i = 0; i < b.currentBoard.GetLength(0); i++)
            {
                for(int j = 0; j < b.currentBoard.GetLength(1); j++)
                {
                    if(b.currentBoard[i,j] != 0 && b.currentBoard[i, j] != value)
                    {
                        distance++;
                    }
                    value++;
                }
            }
            return distance;
        }
    }
}
