using System;
using System.Collections.Generic;

namespace _02._Knight_Game
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var manipulatedBoard = new char[size][];

            for (int i = 0; i < size; i++)
            {
                manipulatedBoard[i] = Console.ReadLine().Trim().ToCharArray();
            }

            var counter = 0;

            while (true)
            {
                var conflict = false;
                var mostDangerous = 0;
                var location = new KeyValuePair<int, int>();

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        var currentEnemies = 0;
                        if (manipulatedBoard[i][j].Equals('0'))
                        {
                            continue;
                        }

                        try
                        {
                            if (manipulatedBoard[i - 2][j - 1].Equals('K'))
                            {
                                currentEnemies++;
                            }
                        }
                        catch (Exception)
                        {
                            //ignored
                        }

                        try
                        {
                            if (manipulatedBoard[i - 2][j + 1].Equals('K'))
                            {
                                currentEnemies++;
                            }
                        }
                        catch (Exception)
                        {
                            //ignored
                        }
                        try
                        {
                            if (manipulatedBoard[i + 2][j - 1].Equals('K'))
                            {
                                currentEnemies++;
                            }
                        }
                        catch (Exception)
                        {
                            //ignored
                        }
                        try
                        {
                            if (manipulatedBoard[i + 2][j + 1].Equals('K'))
                            {
                                currentEnemies++;
                            }
                        }
                        catch (Exception)
                        {
                            //ignored
                        }
                        try
                        {
                            if (manipulatedBoard[i - 1][j - 2].Equals('K'))
                            {
                                currentEnemies++;
                            }
                        }
                        catch (Exception)
                        {
                            //ignored
                        }
                        try
                        {
                            if (manipulatedBoard[i - 1][j + 2].Equals('K'))
                            {
                                currentEnemies++;
                            }
                        }
                        catch (Exception)
                        {
                            //ignored
                        }
                        try
                        {
                            if (manipulatedBoard[i + 1][j - 2].Equals('K'))
                            {
                                currentEnemies++;
                            }
                        }
                        catch (Exception)
                        {
                            //ignored
                        }
                        try
                        {
                            if (manipulatedBoard[i + 1][j + 2].Equals('K'))
                            {
                                currentEnemies++;
                            }
                        }
                        catch (Exception)
                        {
                            //ignored
                        }

                        if (currentEnemies <= mostDangerous)
                        {
                            continue;
                        }

                        mostDangerous = currentEnemies;
                        location = new KeyValuePair<int, int>(i, j);
                    }
                }

                if (mostDangerous > 0)
                {
                    conflict = true;
                    manipulatedBoard[location.Key][location.Value] = '0';
                }
                if (!conflict)
                {
                    break;
                }

                counter++;
            }

            Console.WriteLine(counter);
        }
    }
}