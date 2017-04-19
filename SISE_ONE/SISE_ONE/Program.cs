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
            SolveMethod method;


            method = new BFS();

            method.Solve(Boards.puzzleShuffled, 3, null);


            Console.ReadKey();
        }
    }
}
