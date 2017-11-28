using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISE_ONE
{
    class Astar : SolveMethod
    {
        private Queue<Board> openSet;
        private List<Board> closedSet;

        private string heuristic;
        private string order;

        private int visited = 0;
        private int maxDepth = 0;

        string solutionName;
        string statName;

        public Astar()
        {
            openSet = new Queue<Board>();
            closedSet = new List<Board>();
            heuristic = "manh";
            order = "LUDR";
        }

        public override void Solve(int[,] puzzleToSolve, int puzzleSize, string[] arg)
        {
            solutionName = arg[1];
            statName = arg[2];

            if (arg[0] != null)
                heuristic = arg[0];

            Time.StartTimer();
            Board board = new Board(puzzleSize, puzzleToSolve);
            openSet.Enqueue(board);

            while (openSet.Count > 0)
            {
                openSet = ArrayToQueue(openSet.OrderBy(b => f(b)).ToArray());
                Board first = openSet.Dequeue();
                visited++;

                if (first.depth > maxDepth)
                {
                    maxDepth = first.depth;
                }

                if (first.IsSolved())
                {
                    FileWriter.WriteSolution(first.previousSteps, solutionName);
                    FileWriter.WriteStat(first.previousSteps.Length, visited, closedSet.Count, maxDepth, (float)Time.StopTimer(), statName);
                    return;
                }

                closedSet.Add(first);

                foreach (var item in GetNeighbours(first, order))
                {
                    if (closedSet.Contains(item))
                    {
                        continue;
                    }

                    if (!openSet.Contains(item))
                    {
                        openSet.Enqueue(item);
                    }
                }
            }
        }

        private int f(Board b)
        {
            int g = b.previousSteps.Length;

            int h;

            if (heuristic == "manh")
            {
                h = Manhatan(b);
            }
            else if(heuristic == "hamm")
            {
                h = Hamming(b);
            }
            else
            {
                h = ManhatanExtended(b);
            }

            return g + h;
        }

        private int Manhatan(Board b)
        {
            int distance = 0;
            for (int i = 0; i < b.currentBoard.GetLength(0); i++)
            {
                for (int j = 0; j < b.currentBoard.GetLength(1); j++)
                {
                    int value = b.currentBoard[i, j];
                    if (value > 0)
                    {
                        value--;
                        int x = Math.Abs(j - (value % b.currentBoard.GetLength(1)));
                        int y = Math.Abs(i - (value / b.currentBoard.GetLength(1)));

                        distance += x + y;
                    }
                }
            }
            return distance;
        }

        private int ManhatanExtended(Board b)
        {
            int distance = Manhatan(b);

            distance += LinearConflinctVertical(b) + LinearConflictHorizontal(b);

            return distance;
        }

        private int LinearConflinctVertical(Board b)
        {
            int distance = 0;

            for (int i = 0; i < b.currentBoard.GetLength(0); i++)
            {
                int max = -1;
                for (int j = 0; j < b.currentBoard.GetLength(1); j++)
                {
                    int value = b.currentBoard[i, j];
                    if (value != 0 && (value - 1) / b.currentBoard.GetLength(1) == i)
                    {
                        if (value > max)
                        {
                            max = value;
                        }
                        else
                        {
                            distance += 2;
                        }
                    }
                }
            }

            return distance;
        }

        private int LinearConflictHorizontal(Board b)
        {
            int distance = 0;

            for (int i = 0; i < b.currentBoard.GetLength(0); i++)
            {
                int max = -1;
                for (int j = 0; j < b.currentBoard.GetLength(1); j++)
                {
                    int value = b.currentBoard[j, i];
                    if (value != 0 && (value - 1) / b.currentBoard.GetLength(1) == i)
                    {
                        if (value > max)
                        {
                            max = value;
                        }
                        else
                        {
                            distance += 2;
                        }
                    }
                }
            }

            return distance;
        }

        private int Hamming(Board b)
        {
            int distance = 0;
            int value = 1;
            for (int i = 0; i < b.currentBoard.GetLength(0); i++)
            {
                for (int j = 0; j < b.currentBoard.GetLength(1); j++)
                {
                    if (b.currentBoard[i, j] != 0 && b.currentBoard[i, j] != value)
                    {
                        distance++;
                    }
                    value++;
                }
            }
            return distance;
        }

        private List<Board> GetNeighbours(Board b, string order)
        {
            b.FindEmpty(b.currentBoard);
            List<Board> neighbours = new List<Board>();
            foreach (var item in order)
            {
                switch (item)
                {
                    case 'L':
                        if (b.CanGoLeft())
                            neighbours.Add(new Board(b, 'L'));
                        break;
                    case 'R':
                        if (b.CanGoRight())
                            neighbours.Add(new Board(b, 'R'));
                        break;
                    case 'U':
                        if (b.CanGoUp())
                            neighbours.Add(new Board(b, 'U'));
                        break;
                    case 'D':
                        if (b.CanGoDown())
                            neighbours.Add(new Board(b, 'D'));
                        break;
                }
            }
            return neighbours;
        }

        private Queue<T> ArrayToQueue<T>(T[] items)
        {
            var queue = new Queue<T>();
            Array.ForEach(items, i => queue.Enqueue(i));
            return queue;
        }
    }
}
