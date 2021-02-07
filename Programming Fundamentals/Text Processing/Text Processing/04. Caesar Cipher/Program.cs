using System;

namespace EncryptedText
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            string textForPrint = "";

            for (int i = 0; i < text.Length; i++)
            {
                char currchar = text[i];
                currchar += (char)3;
                textForPrint += currchar;

            }

            Console.WriteLine(textForPrint);
        }
    }
}