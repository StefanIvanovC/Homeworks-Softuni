using System;

namespace DateModifier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string start = Console.ReadLine();
            string end = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();
            var result = dateModifier.GetDaysDifference(start, end);
            Console.WriteLine(result);
            
        }
    }
}
