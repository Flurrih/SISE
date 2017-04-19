using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISE_ONE
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] targetBoard =
            {
                {1,2,3 },
                {4,5,6 },
                {7,8,0 }
            };
            int[,] puzzleShuffled =
            {
                {1,2,3 },
                {4,6,8 },
                {7,5,0 }
            };
            int[,] puzzleSolved =
            {
                {1,2,3 },
                {4,5,6 },
                {7,8,0 }
            };
            Board board = new Board(3, puzzleSolved);

            board.PrintCurrentBoard();



            Console.ReadKey();
        }
    }
}
