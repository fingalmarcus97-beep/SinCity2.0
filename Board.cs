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
        public static void DrawBoard(int  width, int height, Person person, List<Person> register)
        {

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

                    else if (i == person.PositionY && j == person.PositionX)
                    {
                        foreach (var people in register)
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