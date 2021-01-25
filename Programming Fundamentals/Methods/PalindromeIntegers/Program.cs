using System;

namespace mirrorMumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var strInput = Console.ReadLine();

            while (strInput != "END")
            {
                var start = strInput[0];
                char end = ' ';

                for (int i = 0; i < strInput.Length; i++)
                {
                    end = strInput[i];
                }

                if (start == end)
                {
                    Console.WriteLine("true");
                }

                else
                {
                    Console.WriteLine("false");
                }

                strInput = Console.ReadLine();
            }

        }
    }
}
