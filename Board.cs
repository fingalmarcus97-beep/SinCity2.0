using Microsoft.Win32;
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

        public static void CityBoard(int width, int height, List<Person> cityRegister)
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var peoples = cityRegister.Where(people => people.PositionX == x && people.PositionY == y).ToList();

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
                        Person p = peoples.First();
                        if (p is Citizen)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (p is Thief)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        else if (p is Police)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (p is Murderer)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        }
                        Console.Write(p.Appearance);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Movement(width, height, cityRegister);
            Thread.Sleep(100);
        }

        public static void PrisonBoard(int width, int height, List<Person> prisonRegister, List<Person> cityRegister)
        {
            Console.SetCursorPosition(0, 29);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var peoples = prisonRegister.Where(prisoners => prisoners.PositionX == x && prisoners.PositionY == y).ToList();
                    if (y == 0 && x == 1)
                    {
                        Console.Write(" Prison ");
                        x += 7;
                    }
                    else if (y == height - 1 || y == 0 || x == width - 1 || x == 0)
                    {
                        Console.Write("█");
                    }
                    else if (peoples.Any())
                    {
                        Person p = peoples.First();
                        if (p is Thief)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        Console.Write(p.Appearance);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Movement(width, height, prisonRegister);

            Release(prisonRegister, cityRegister);
        }

        public static void PoorBoard(int width, int height, List<Person> poorRegister)
        {
            for (int y = 0; y < height; y++)
            {
                Console.SetCursorPosition(11, 29 + y);
                for (int x = 0; x < width; x++)
                {
                    var peoples = poorRegister.Where(poorPeople => poorPeople.PositionX == x && poorPeople.PositionY == y).ToList();
                    if (y == 0 && x == 1)
                    {
                        Console.Write(" Poorhouse ");
                        x += 10;
                    }
                    else if (y == height - 1 || y == 0 || x == width - 1 || x == 0)
                    {
                        Console.Write("█");
                    }
                    else if (peoples.Any())
                    {
                        Person p = peoples.First();
                        if (p is Citizen)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.Write(p.Appearance);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Movement(width, height, poorRegister);
        }

        public static void Movement(int width, int height, List<Person> register)
        {
            foreach (Person move in register)
            {
                move.PositionX += move.DirectionX;
                move.PositionY += move.DirectionY;

                if (move.PositionX >= width - 1)
                {
                    move.PositionX = 1;
                }
                if (move.PositionY >= height - 1)
                {
                    move.PositionY = 1;
                }
                if (move.PositionX <= 0)
                {
                    move.PositionX = width - 2;
                }
                if (move.PositionY <= 0)
                {
                    move.PositionY = height - 2;
                }
            }
        }

        public static void Reg(List<Person> cityRegister)
        {

            for (int i = 0; i < 20; i++)
            {
                cityRegister.Add(new Citizen(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), Person.SetName()));
            }
            for (int i = 0; i < 10; i++)
            {
                cityRegister.Add(new Thief(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), Person.SetName()));
            }
            for (int i = 0; i < 5; i++)
            {
                cityRegister.Add(new Police(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), Person.SetName()));
            }
        }

        public static void MoveToPoorhouse(List<Person> cityRegister, List<Person> poorRegister)
        {
            foreach (Person poor in cityRegister.ToList())
            {
                if (poor is Citizen && poor.Inventory.Count == 0)
                {
                    cityRegister.Remove(poor);
                    poorRegister.Add(poor);
                }
            }
        }

        public static void ToPrison(Thief thief, List<Person> prisonRegister, List<Person> cityRegister)
        {
            int prisonTime = thief.Inventory.Count * 10;
            thief.Inventory.Clear();
            thief.PrisonSentence = DateTime.Now.AddSeconds(prisonTime);
            cityRegister.Remove(thief);
            prisonRegister.Add(thief);
        }

        public static void Release(List<Person> prisonRegister, List<Person> cityRegister)
        {
            foreach (Thief thief in prisonRegister.ToList())
            {
                if (DateTime.Now >= thief.PrisonSentence)
                {
                    prisonRegister.Remove(thief);
                    cityRegister.Add(thief);
                }
            }
        }
    }
}