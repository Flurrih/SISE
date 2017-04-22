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
            //string method = args[0];
            //string order = args[1];
            //string boardName = args[2];
            //string solutionName = args[3];
            //string statName = args[4];
            SolveMethod solveMethod;

            //switch (method)
            //{
            //    case "bfs":
            //        solveMethod = new BFS();
            //        break;
            //    case "dfs":
            //        solveMethod = new DFS();
            //        break;
            //    case "manh":
            //        solveMethod = new Astar();
            //        break;
            //    case "hamm":
            //        solveMethod = new Astar();
            //        break;
            //}
            solveMethod = new DFS();

            //solveMethod.Solve(Boards.puzzleShuffled2, 4, order);
            //method.Solve(Boards.puzzleShuffled2, 4, new string[] { "hamm", null });

            //int[,] b = FileReader.ReadBoard("4x4_01_00001.txt");
            solveMethod.Solve(FileReader.ReadBoard("4x4_01_00001.txt"), 4, "LUDR");

            Console.ReadKey();
        }
    }
}
