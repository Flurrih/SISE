using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISE_ONE
{
    class BFS : SolveMethod
    {

        Queue<Board> boardsQueue;
        Board puzzleBoard;
        public override void Solve(int[,] puzzleToSolve, int puzzleSize, string arg)
        {
            boardsQueue = new Queue<Board>();
            puzzleBoard = new Board(puzzleSize, puzzleToSolve);
            puzzleBoard.PrintCurrentBoard();
            if(puzzleBoard.IsSolved())
            {
                Console.WriteLine("Puzzle is already solved!");
                return;
            }
            else
            {
                SeekDirections("LU");
            }
        }

        void SeekDirections(string order)
        {
            foreach (char ch in order)
            {
                boardsQueue.Enqueue(new Board(puzzleBoard, ch));
            }
            foreach (var board in boardsQueue)
            {
                Console.WriteLine();
                board.PrintCurrentBoard();
            }
        }
        
    }
}
