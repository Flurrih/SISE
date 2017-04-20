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
        List<Board> finishedBoards;
        Board puzzleBoard;
        public override void Solve(int[,] puzzleToSolve, int puzzleSize, string arg)
        {
            boardsQueue = new Queue<Board>();
            finishedBoards = new List<Board>();
            puzzleBoard = new Board(puzzleSize, puzzleToSolve);
            puzzleBoard.PrintCurrentBoard();
            if(puzzleBoard.IsSolved())
            {
                Console.WriteLine("Puzzle is already solved!");
                return;
            }
            else
            {
                SeekDirections("LUDR", puzzleBoard);
                
                while(boardsQueue.Count > 0)
                {
                    if(SearchQueue("LUDR"))
                    {
                        Console.WriteLine("Leaving loop... Jobs done");
                        break;
                    }
                }
                Console.WriteLine("LEft");
            }
        }

        void SeekDirections(string order, Board b)
        {
            b.FindEmpty(b.currentBoard);
            foreach (char ch in order)
            {
                switch (ch)
                {
                    case 'L':
                        if(b.CanGoLeft())
                            AddBoardToQueue(new Board(b, 'L'));
                        break;
                    case 'R':
                        if (b.CanGoRight())
                            AddBoardToQueue(new Board(b, 'R'));
                        break;
                    case 'U':
                        if (b.CanGoUp())
                            AddBoardToQueue(new Board(b, 'U'));
                        break;
                    case 'D':
                        if (b.CanGoDown())
                            AddBoardToQueue(new Board(b, 'D'));
                        break;
                }
                
            }
            foreach (var item in boardsQueue)
            {
                //Console.WriteLine();
                //item.PrintCurrentBoard();
            }
        }
        
        bool SearchQueue(string order)
        {
            Board currBoard = boardsQueue.Dequeue();
            if (currBoard.IsSolved())
            {
                //Console.WriteLine("DLA OLI:");
                //currBoard.PrintCurrentBoard();
                Console.WriteLine("Puzzle is already solved!");
                return true;

                //TODO Stopwatch
            }
            SeekDirections(order, currBoard);
            AddBoardToFinished(currBoard);
            return false;
        }

        void AddBoardToFinished(Board board)
        {
            if(!finishedBoards.Contains(board))
            {
                finishedBoards.Add(board);
                //board.PrintCurrentBoard();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
            }
        }

        void AddBoardToQueue(Board board)
        {
            if(!finishedBoards.Contains(board) && !boardsQueue.Contains(board))
            {
                boardsQueue.Enqueue(board);
            }
            else
            {
                Console.WriteLine();
            }

            
        }

    }
}
