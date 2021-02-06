using System;
using System.Linq;
using System.Text;

namespace TextProcesingStringBilder
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.None).ToArray();

            foreach (var item in input)
            {
                if (ValidateUserName(item))
                {
                    Console.WriteLine(item);
                }

            }

        }

        private static bool ValidateUserName(string username)
        {


            if (username.Length < 3 || username.Length > 16)
            {
                return false;
            }

            bool isValid = true;

            for (int i = 0; i < username.Length; i++)
            {
                char currChar = username[i];

                if (!(char.IsLetterOrDigit(currChar) || currChar == '-' || currChar == '_'))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }
    }
}
