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
                SeekDirections("LUDR");
            }
        }

        void SeekDirections(string order)
        {
            foreach (char ch in order)
            {
                switch (ch)
                {
                    case 'L':
                        if(puzzleBoard.CanGoLeft())
                            boardsQueue.Enqueue(new Board(puzzleBoard, ch));
                        break;
                    case 'R':
                        if (puzzleBoard.CanGoRight())
                            boardsQueue.Enqueue(new Board(puzzleBoard, ch));
                        break;
                    case 'U':
                        if (puzzleBoard.CanGoUp())
                            boardsQueue.Enqueue(new Board(puzzleBoard, ch));
                        break;
                    case 'D':
                        if (puzzleBoard.CanGoDown())
                            boardsQueue.Enqueue(new Board(puzzleBoard, ch));
                        break;
                }
                
            }
            foreach (var board in boardsQueue)
            {
                Console.WriteLine();
                board.PrintCurrentBoard();
            }
        }
        
    }
}
