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
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 && j == 2)
                    {
                        Console.Write(" SINCITY ");
                        j += 9;
                    }
                    if (i == height - 1 || i == 0 || j == width - 1 || j == 0)
                    {
                        Console.Write("█");
                    }

                    if(i == person.PositionY && j == person.PositionX)
                    {
                        Console.SetCursorPosition(i, j);
                        
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