using System;

namespace ReplaceRepeatingCharInString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var countOfRemoves = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                var currChar = input[i];
                for (int j = i + 1; j < input.Length; j++)
                {
                    var secondChar = input[j];
                    if (currChar == secondChar)
                    {
                        countOfRemoves++;
                    }
                    else
                    {
                        break;
                    }

                }
                input = input.Remove(i + 1, countOfRemoves);
                countOfRemoves = 0;
            }

            Console.WriteLine(input);
        }
    }
}