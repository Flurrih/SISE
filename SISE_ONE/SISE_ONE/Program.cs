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


            method = new Astar();

            method.Solve(Boards.puzzleShuffled2, 4, "hamm");
            method.Solve(Boards.puzzleShuffled2, 4, "manh");


            Console.ReadKey();
        }
    }
}
