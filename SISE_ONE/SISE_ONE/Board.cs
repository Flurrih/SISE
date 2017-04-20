using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISE_ONE
{
    class Board
    {
        public int[,] currentBoard;
        public string previousSteps;
        int boardSize;
        int[] currentPosition;

        public Board(int boardSize, int[,] board)
        {
            this.boardSize = boardSize;
            currentBoard = board;
            currentPosition = new int[2];
            FindEmpty(currentBoard);
        }
        public void PrintCurrentBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write(currentBoard[i, j]);
                }
                Console.WriteLine();
            }

        }
        public bool IsSolved()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (currentBoard[i, j] != Boards.targetBoard[i, j])
                        return false;
                }
            }
            return true;
        }

        public Board(Board board , char direction)
        {
            this.boardSize = board.boardSize;
            currentPosition = new int[2];
            currentBoard = (int[,])board.currentBoard.Clone();
            FindEmpty(currentBoard);
            this.previousSteps = board.previousSteps;
            
            switch (direction)
            {
                case 'L':
                    {
                        currentBoard[currentPosition[0], currentPosition[1]] = currentBoard[currentPosition[0] , currentPosition[1] - 1];
                        currentBoard[currentPosition[0] , currentPosition[1] - 1] = 0;
                        previousSteps += 'L';
                    }
                    break;
                case 'R':
                    {
                        currentBoard[currentPosition[0], currentPosition[1]] = currentBoard[currentPosition[0] , currentPosition[1] + 1];
                        currentBoard[currentPosition[0] , currentPosition[1] + 1] = 0;
                        previousSteps += 'R';
                    }
                    break;
                case 'D':
                    {
                        currentBoard[currentPosition[0], currentPosition[1]] = currentBoard[currentPosition[0] + 1, currentPosition[1]];
                        currentBoard[currentPosition[0] + 1, currentPosition[1] ] = 0;
                        previousSteps += 'D';
                    }
                    break;
                case 'U':
                    {
                        currentBoard[currentPosition[0], currentPosition[1]] = currentBoard[currentPosition[0] - 1, currentPosition[1]];
                        currentBoard[currentPosition[0] - 1, currentPosition[1]] = 0;
                        previousSteps += 'U';
                    }
                    break;

            }
            
        }

        public bool CanGoDown()
        {
            if (currentPosition[0] < boardSize - 1)
            {
                Console.WriteLine("Can Go Down");
                return true;
            }
            Console.WriteLine("Can't Go Down");
            return false;
        }

        public bool CanGoUp()
        {
            if (currentPosition[0] > 0)
            {
                Console.WriteLine("Can Go Up");
                return true;
            }
            Console.WriteLine("Can't Go Up");
            return false;
        }

        public bool CanGoRight()
        {
            if (currentPosition[1] < boardSize - 1)
            {
                Console.WriteLine("Can Go Right");
                return true;
            }
            Console.WriteLine("Can't Go Right");
            return false;
        }

        public bool CanGoLeft()
        {
            if (currentPosition[1] > 0)
            {
                Console.WriteLine("Can Go Left");
                return true;
            }

            Console.WriteLine("Can't Go Left");
            return false;
        }

        public void FindEmpty(int[,] board)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (currentBoard[i, j].Equals(0))
                    {
                        currentPosition[0] = i;
                        currentPosition[1] = j;
                    }
                }
            }
        }

    }
}
