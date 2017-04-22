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
                {1,2,3, 4},
                {5, 6, 7, 8 },
                {9, 10, 11, 12 },
                {13, 14, 15 , 0 }
        };
        public static int[,] puzzleShuffled =
        {
                {1,2,3,4 },
                {5,6,7,8 },
                {9,10,11,12 },
                {13,14,0,15 }
        };
        public static int[,] puzzleShuffled2 =
        {
                {1,2,3, 4},
                {5, 6, 8, 12 },
                {9, 11, 7, 0 },
                {13, 10, 14 , 15 }
        };
        public static int[,] puzzleSolved =
        {
                {1,2,3 },
                {4,5,6 },
                {7,8,0 }
        };

        public static int[,] puzzleShuffled3 =
            { 
            { 1,6,2,3, },
            { 5,10,7,4, },
            { 9,0,11,8, },
            { 13,14,15,12 }
        };
    }
}
