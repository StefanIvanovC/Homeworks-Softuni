using System;
using System.Linq;

namespace Top_Intagers_In_Arreys
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var result = "";

            for (int i = 0; i < arr.Length; i++)
            {
                var curr = arr[i];
                var check = true;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (curr <= arr[j])
                    {
                        check = false;
                        break;
                    }
                }

                if (check)
                {
                    result += curr + " ";
                }

            }

            Console.WriteLine(result);
        }
    }
}