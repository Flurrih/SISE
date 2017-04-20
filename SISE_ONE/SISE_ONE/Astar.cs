using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISE_ONE
{
    class Astar : SolveMethod
    {
        private SortedList<int, int[,]> openSet;
        private List<int[,]> closedSet;

        private string heuristic;

        public Astar()
        {
            openSet = new SortedList<int, int[,]>();
            closedSet = new List<int[,]>();
            heuristic = "manh";
        }

        public override void Solve(int[,] puzzleToSolve, int puzzleSize, string arg)
        {
            Board board = new Board(puzzleSize, puzzleToSolve);
            openSet.Add(f(board), board.currentBoard);
            while(openSet.Count > 0)
            {
                
            }
            
            if(arg != null)
                heuristic = arg;
        }

        private int f(Board b)
        {
            int g = b.previousSteps.Length;

            int h;

            if(heuristic == "manh")
            {
                h = Manhatan();
            }
            else
            {
                h = 0;
            }

            return g + h;
        }

        private int Manhatan()
        {
            return 1;
        }
    }
}
