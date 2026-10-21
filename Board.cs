using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

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
            string[] namnLista =
            {
                "Andersson","Johansson","Karlsson","Nilsson","Eriksson",
                "Larsson","Olsson","Persson","Svensson","Gustafsson","Lindberg",
                "Lundgren","Bergström","Holm","Sandberg","Björk",
                "Dahl","Berg","Nyström","Håkansson","Ström",
                "Lindqvist","Mattsson","Fredriksson","Wallin",
                "Ekström","Axelsson","Berglund","Samuelsson",
                "Löfgren","Hellström","Blomqvist","Norberg",
                "Åkesson","Sahlberg","Edlund","Boström","Isaksson","Marklund",
                "Sjöberg"
            };
            Random rnd = new Random();
            
            for (int i = 0; i < 20; i++)
            {
                string name = namnLista[rnd.Next(namnLista.Length)];
                register.Add(new Citizen(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), name));
            }
            for (int i = 0; i < 10; i++)
            {
                string name = namnLista[rnd.Next(namnLista.Length)];
                register.Add(new Thief(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), name));
            }
            for (int i = 0; i < 5; i++)
            {
                string name = namnLista[rnd.Next(namnLista.Length)];
                register.Add(new Police(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), name));
            }

        }
        //public static void Movement()
        //{
        //    Random random = new Random();


        //}


        public static void DrawBoard(int width, int height, List<Person> register)
        {
            while (true)
            {
                Random rnd = new Random();
                Console.SetCursorPosition(0, 0);
                Console.CursorVisible = false;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        var peoples = register.Where(people => people.PositionX == x && people.PositionY == y).ToList();

                        if (y == 0 && x == 2)
                        {
                            Console.Write(" SINCITY ");
                            x += 8;
                        }
                        else if (y == height - 1 || y == 0 || x == width - 1 || x == 0)
                        {
                            Console.Write("█");
                        }
                        else if (peoples.Any())
                        {
                            foreach (Person p in peoples)
                            {
                                if (p is Citizen)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                else if (p is Thief)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                }
                                else if (p is Police)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                }

                                Console.Write(p.Appearance);
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
                foreach (Person move in register)
                {
                    move.PositionX += move.DirectionX;
                    move.PositionY += move.DirectionY;

                    if (move.PositionX > 100)
                    {
                        move.PositionX = 1;
                    }
                    if (move.PositionY > 25)
                    {
                        move.PositionY = 1;
                    }
                    if (move.PositionX < 0)
                    {
                        move.PositionX = 99;
                    }
                    if (move.PositionY < 0)
                    {
                        move.PositionY = 24;
                    }
                }
                {
                    
                }
                Thread.Sleep(10);
            }
        }
    }
}