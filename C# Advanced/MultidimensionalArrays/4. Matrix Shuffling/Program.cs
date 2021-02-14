using System;
using System.Data;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Input(' ');
            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);
            var matrix = new String[rows, cols];

            CreateMatrix(matrix, rows, cols);
            while (true)
            {
                var command = Command(' ');
                if (command.Contains("END"))
                {
                    break;
                }

                if (!CommandIsValid(command))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                var swap = command.Skip(1).Select(int.Parse).ToArray();
                if (!CommandIsValid(matrix, swap))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                Swap(matrix, swap);
                PrintMatrix(matrix);
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        static void CreateMatrix(string[,] matrix, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                var currentRow = Input(' ');
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }
        }

        static void Swap(string[,] matrix, int[] arr)
        {
            var row = arr[0];
            var col = arr[1];
            var row1 = arr[2];
            var col1 = arr[3];

            var ferstValue = matrix[row, col];
            var secoValue = matrix[row1, col1];
            matrix[row, col] = secoValue;
            matrix[row1, col1] = ferstValue;
        }

        static bool CommandIsValid(string[] command)
            => command.Contains("swap") &&
               command.Length <= 5;

        static bool CommandIsValid(string[,] matrix, int[] command)
            => (command[0] >= 0 && matrix.GetLength(0) >= command[0]) &&
               (command[1] >= 0 && matrix.GetLength(1) >= command[1]) &&
               (command[2] >= 0 && matrix.GetLength(0) >= command[2]) &&
               (command[3] >= 0 && matrix.GetLength(1) >= command[3]);

        static string[] Command(params char[] separator)
            => Console.ReadLine()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

        static string[] Input(params char[] separator)
            => Console.ReadLine()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
    }
}