using System;
using System.Collections.Generic;
using System.Text;

namespace SinCity2._0
{
    internal class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public static void Reg(List<Person> register)
        {
            for (int i = 0; i < 2; i++)
            {
                register.Add(new Citizen(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), "C"));
            }
            for (int i = 0; i < 1; i++)
            {
                register.Add(new Thief(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), "T"));
            }
            for (int i = 0; i < 1; i++)
            {
                register.Add(new Police(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), "P"));
            }

        }
        public static void DrawBoard(int width, int height, List<Person> register)
        {
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.CursorVisible = false;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (i == 0 && j == 2)
                        {
                            Console.Write(" SINCITY ");
                            j += 8;
                        }
                        else if (i == height - 1 || i == 0 || j == width - 1 || j == 0)
                        {
                            Console.Write("█");
                        }

                        else if (register.Any(people => people.PositionX == j && people.PositionY == i))
                        {
                            foreach(Person person in register)
                            {
                                Console.Write(person.Appearance);
                            }
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }






            }
        }
    }
}