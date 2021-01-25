using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            if (!IsValidLenght(text))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!IsLetherOrDigit(text))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!IsHasTwoDigits(text))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (IsValidLenght(text) && IsLetherOrDigit(text) && IsHasTwoDigits(text))
            {
                Console.WriteLine("Password is valid");
            }

        }

        static bool IsValidLenght(string password)
        {
            return (password.Length >= 6 && password.Length <= 10);

        }

        static bool IsLetherOrDigit(string password)
        {
            foreach (var character in password)
            {
                var oneChar = character;
                if (!char.IsLetterOrDigit(oneChar))
                {
                    return false;
                }


            }
            return true;
        }

        static bool IsHasTwoDigits(string Password)
        {
            int counter = 0;

            foreach (var item in Password)
            {
                if (char.IsDigit(item))
                {
                    counter++;
                }
            }
            return counter >= 2;
        }

    }
}