using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISE_ONE
{
    class FileWriter
    {
        public static void WriteSolution(string sol, string filename)
        {
            string solution = sol.Length + "\r\n" + sol;
            System.IO.StreamWriter file = new System.IO.StreamWriter("F:/SISE/sise_test/Solutions/" + filename);
            file.WriteLine(solution);

            file.Close();
        }

        public static void WriteStat(int sol, int visited, int processed, int maxDepth, float time, string filename)
        {
            string solution = sol + "\r\n" + visited + "\r\n" + processed + "\r\n" + maxDepth + "\r\n" + time;
            System.IO.StreamWriter file = new System.IO.StreamWriter("F:/SISE/sise_test/Statistics/" + filename);
            file.WriteLine(solution);

            file.Close();
        }
    }
}
