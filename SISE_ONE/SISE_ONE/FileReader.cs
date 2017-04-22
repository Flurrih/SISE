using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISE_ONE
{
    class FileReader
    {
        public static int[,] ReadBoard(string name)
        {
            int[,] newBoard = new int[4, 4];
            TextReader reader = File.OpenText("F:/SISE/sise_test/Boards/" +name);
            String sizeInput = reader.ReadLine();
            for (int i = 0; i < 4; i++)
            {

                String input = reader.ReadLine();
                String[] num = input.Split(' ');
                for (int j = 0; j < num.Length; j++)
                {
                    newBoard[i, j] = int.Parse(num[j]);
                }

            }

            return newBoard;
        }
    }
}
