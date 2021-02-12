using System;
using System.Linq;

namespace arraysseptember
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] intMatrix = new int[n, n];
            FillMatrix(intMatrix);
            PrintMartix(intMatrix, n);
        }

        private static void PrintMartix(int[,] intMatrix, int N)
        {
            int currentSumPrimaryDiagonal = 0;
            int currentSumSecondariDiagonal = 0;
            for (int row = 0; row < intMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < intMatrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        currentSumPrimaryDiagonal += intMatrix[row, col];
                    }
                    if (col == intMatrix.GetLength(0) - 1 - row)
                    {
                        currentSumSecondariDiagonal += intMatrix[row, col];
                    }
                }
            }

            int dev = 0;
            int dev2 = 0;
            if (currentSumPrimaryDiagonal > currentSumSecondariDiagonal)
            {
                dev = currentSumPrimaryDiagonal;
                dev2 = currentSumSecondariDiagonal;
            }
            if (currentSumSecondariDiagonal > currentSumPrimaryDiagonal)
            {
                dev = currentSumSecondariDiagonal;
                dev2 = currentSumPrimaryDiagonal;
            }

            Console.WriteLine(dev - dev2);
        }
        private static void FillMatrix(int[,] intMatrix)
        {
            for (int row = 0; row < intMatrix.GetLength(0); row++)
            {
                var current = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < intMatrix.GetLength(1); col++)
                {
                    intMatrix[row, col] = current[col];
                }
            }
        }
    }
}