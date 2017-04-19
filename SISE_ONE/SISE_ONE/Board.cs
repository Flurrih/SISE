using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISE_ONE
{
    class Board
    {
        int[,] currentBoard;
        //List<string> previousSteps;
        int boardSize;
        public Board(int boardSize, int[,] board)
        {
            this.boardSize = boardSize;
            currentBoard = board;
        }
        public void PrintCurrentBoard()
        {
            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    Console.WriteLine(currentBoard[i, j]);
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



    }
}
