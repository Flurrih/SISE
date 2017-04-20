﻿using System;
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
                {1,2,3 },
                {4,6,8 },
                {7,5,0 }
        };
        public static int[,] puzzleShuffled2 =
        {
                {1,2,3, 4},
                {5, 6, 7, 8 },
                {10, 13, 11, 12 },
                {9, 14, 0 , 15 }
        };
        public static int[,] puzzleSolved =
        {
                {1,2,3 },
                {4,5,6 },
                {7,8,0 }
        };
    }
}
