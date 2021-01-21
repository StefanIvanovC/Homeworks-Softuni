using System;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputText = Console.ReadLine().ToLower();
            char[] Inputchars = inputText.ToCharArray();
            int counter = 0;

            for (int i = 0; i < Inputchars.Length; i++)
            {
                if (inputText[i] == 'a' || inputText[i] == 'e' || inputText[i] == 'i' ||
                    inputText[i] == 'o' || inputText[i] == 'u' || inputText[i] == 'y')
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}