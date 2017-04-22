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
            int[,] board;
            try
            {
                using (StreamReader sr = new StreamReader("F:/SISE/sise_test/Boards/"+ name) )
                {
                    //string[] args = sr.ReadToEnd().Split(' ');
                    int[] args 
                    int sizeX = Int32.Parse(args[0]);
                    int sizeY = Int32.Parse(args[1]);
                    board = new int[sizeX, sizeY];
                    int ct = 2;
                    for (int i = 0; i < sizeX; i++)
                    {
                        for (int j = 0; j < sizeY; j++)
                        {
                            board[i, j] = Int32.Parse(args[ct]);
                        }
                    }
                    return board;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
