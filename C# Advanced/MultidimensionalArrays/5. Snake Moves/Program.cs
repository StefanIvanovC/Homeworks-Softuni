using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int r = nums[0];
            int c = nums[1];
            char[,] matrix = new char[r, c];
            string snake = Console.ReadLine();
            int counter = 0;
            var myQue = new Queue<char>();

            int capacity = r * c;

            for (int i = 0; i < snake.Length; i++)
            {
                myQue.Enqueue(snake[i]);
                counter++;

                if (counter == capacity)
                {
                    break;
                }
                if (i == snake.Length - 1)
                {
                    i = -1;
                }
            }

            for (int j = 0; j < r; j++)
            {
                if (j % 2 == 0)
                {
                    for (int i = 0; i < c; i++)
                    {
                        matrix[j, i] = myQue.Dequeue();
                    }
                }
                else if (j % 2 != 0)
                {
                    for (int k = c - 1; k > -1; k--)
                    {
                        matrix[j, k] = myQue.Dequeue();
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}