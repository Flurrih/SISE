using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISE_ONE
{
    static class Boards
    {
        public static int[,] targetBoard =
        {
                {1,2,3 },
                {4,5,6 },
                {7,8,0 }
        };
        public static int[,] puzzleShuffled =
        {
                {1,2,3 },
                {4,6,8 },
                {7,5,0 }
        };
        public static int[,] puzzleShuffled2 =
        {
                {1,3,7 },
                {8,2,0 },
                {5,4,6 }
        };
        public static int[,] puzzleSolved =
        {
                {1,2,3 },
                {4,5,6 },
                {7,8,0 }
        };
    }
}
