using System;
using System.Linq;

namespace Squares_in_Matrix
{
    class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrixChar = new char[size[0], size[1]];

            for (int i = 0; i < matrixChar.GetLength(0); i++)
            {
                char[] rowInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < matrixChar.GetLength(1); j++)
                {
                    matrixChar[i, j] = rowInput[j];
                }
            }

            int countSquares2x2 = 0;
            for (int i = 0; i < matrixChar.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrixChar.GetLength(1) - 1; j++)
                {
                    if (matrixChar[i, j] == matrixChar[i, j + 1] &&
                        matrixChar[i, j] == matrixChar[i + 1, j + 1] &&
                        matrixChar[i, j] == matrixChar[i + 1, j])
                    {
                        countSquares2x2++;
                    }
                }
            }

            Console.WriteLine(countSquares2x2);
        }
    }
}