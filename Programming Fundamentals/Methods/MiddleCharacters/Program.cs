using System;

namespace middlePrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Print(text);
        }

        static void Print(string text)
        {
            var textLenght = text.Length;

            if (textLenght % 2 != 0)
            {
                var chToPrint = textLenght / 2;

                for (int i = 1; i <= textLenght + 1; i++)
                {
                    if (i == chToPrint)
                    {
                        Console.WriteLine(text[i]);
                    }
                }

            }

            else if (textLenght % 2 == 0)
            {
                var chToPrint = textLenght / 2;

                for (int i = 1; i <= textLenght + 1; i++)
                {
                    if (i == chToPrint)
                    {
                        Console.WriteLine(text[i - 1] + "" + text[i]);
                    }
                }
            }
        }
    }
}