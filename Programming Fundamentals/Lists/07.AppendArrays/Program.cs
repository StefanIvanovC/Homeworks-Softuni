namespace _07_AppendArrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class AppendArrays
    {
        public static void Main()
        {
            var input = Console.ReadLine().
                Split('|', StringSplitOptions.RemoveEmptyEntries).
                ToList();
            var newList = new List<int>();
            var list = new List<int>();
            for (int i = input.Count - 1; i >= 0; i--)
            {
                newList = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                foreach (var item in newList)
                {
                    list.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}