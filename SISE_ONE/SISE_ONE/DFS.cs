using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISE_ONE
{
    class DFS : SolveMethod
    {
        int depth;
        int maxDepth;
        Stack<Board> boardsHashSet;
        HashSet<Board> finishedBoards;
        Board puzzleBoard;
        int processed = 1;
        int visited = 1;
        public override void Solve(int[,] puzzleToSolve, int puzzleSize, string arg)
        {
            maxDepth = 25;
            boardsHashSet = new Stack<Board>();
            finishedBoards = new HashSet<Board>();
            puzzleBoard = new Board(puzzleSize, puzzleToSolve);
            puzzleBoard.PrintCurrentBoard();
            if (puzzleBoard.IsSolved())
            {
                Console.WriteLine("Puzzle is already solved!");
                return;
            }
            else
            {
                Time.StartTimer();
                SeekDirections("LUDR", puzzleBoard);

                while (boardsHashSet.Count > 0)
                {
                    if (SearchQueue("LUDR"))
                    {
                        Console.WriteLine("Leaving loop... Jobs done");
                        break;
                    }
                }
                Console.WriteLine(Time.StopTimer());
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
                        if (b.CanGoLeft())
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
        }

        bool SearchQueue(string order)
        {
            Board currBoard = boardsHashSet.Pop();
            visited++;
            if (depth < currBoard.depth)
            {
                depth = currBoard.depth;
            }
            if (currBoard.IsSolved())
            {
                Console.WriteLine("Puzzle is already solved!: " + currBoard.previousSteps);
                Console.WriteLine(processed + " " + visited);
                return true;
            }
            if(maxDepth > currBoard.depth)
            {
                SeekDirections(order, currBoard);
                AddBoardToFinished(currBoard);
                processed++;
            }
            return false;

        }

        void AddBoardToFinished(Board board)
        {
            if (!finishedBoards.Contains(board))
            {
                finishedBoards.Add(board);
            }
        }

        void AddBoardToQueue(Board board)
        {
            if (!finishedBoards.Contains(board) && !boardsHashSet.Contains(board))
            {
                boardsHashSet.Push(board);
            }
        }

    }
}
