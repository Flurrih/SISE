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
            string method = args[0];
            string order = args[1];
            string boardName = args[2];
            string solutionName = args[3];
            string statName = args[4];
            SolveMethod solveMethod;
            switch (method)
            {
                case "bfs":
                    solveMethod = new BFS();
                    break;
                case "dfs":
                    solveMethod = new DFS();
                    break;
                case "manh":
                    solveMethod = new Astar();
                    break;
                case "hamm":
                    solveMethod = new Astar();
                    break;
                default:
                    solveMethod = new BFS();
                    break;
            }
            //solveMethod = new DFS();

            //solveMethod.Solve(Boards.puzzleShuffled2, 4, order);
            //method.Solve(Boards.puzzleShuffled2, 4, new string[] { "hamm", null });

            //int[,] b = FileReader.ReadBoard("4x4_01_00001.txt");

            int[,] board = FileReader.ReadBoard(boardName);
            if (IsSolvable(board, 3))
            {
                solveMethod.Solve(board, 4, new string[] { order, solutionName, statName});
            }
            else
            {
                FileWriter.WriteSolution("-1", solutionName);
            }

            Console.ReadKey();
        }
        public static bool IsSolvable(int[,] board, int size)
        {
            int parity = 0;
            int row = 0; // the current row we are on
            int blankRow = 0; // the row with the blank tile
            int it = 0;
            int[] puzzle = new int[size * size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    puzzle[it] = board[i, j];
                    it++;
                }
            }
            for (int i = 0; i < size * size; i++)
            {
                if (i % size == 0)
                { // advance to next row
                    row++;
                }
                if (puzzle[i] == 0)
                { // the blank tile
                    blankRow = row; // save the row on which encountered
                    continue;
                }
                for (int j = i + 1; j < size * size; j++)
                {
                    if (puzzle[i] > puzzle[j] && puzzle[j] != 0)
                    {
                        parity++;
                    }
                }
            }

            if (size % 2 == 0)
            { // even grid
                if (blankRow % 2 == 0)
                { // blank on odd row; counting from bottom
                    return parity % 2 == 0;
                }
                else
                { // blank on even row; counting from bottom
                    return parity % 2 != 0;
                }
            }
            else
            { // odd grid
                return parity % 2 == 0;
            }
        }
    }
}
