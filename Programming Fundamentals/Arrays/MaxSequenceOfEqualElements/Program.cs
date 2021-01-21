using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine()
                .Split(' ').Select(int.Parse).ToList();

            int maxSequenceLength = 0;
            int maxSequenceStartIndex = 0;
            int maxSequenceEndIndex = -1;

            for (int i = 0; i < inputList.Count - 1; i++)
            {
                int startIndex = i;
                int length = 1;

                while (i < inputList.Count - 1 && inputList[i] == inputList[i + 1])
                {
                    length++;
                    i++;
                }
                if (length > maxSequenceLength)
                {
                    maxSequenceLength = length;
                    maxSequenceStartIndex = startIndex;
                    maxSequenceEndIndex = i;
                }
            }
            for (int i = maxSequenceStartIndex; i <= maxSequenceEndIndex; i++)
            {
                Console.Write(inputList[i] + " ");
            }
        }
    }
}