using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace SinCity2._0
{
    internal class Interaction
    {
        static int newsNumber = 0;
        public static int arrestedNumber = 0;
        public static int robbedNumber = 0;
        public static int murderedNumber = 0;

        public static void Interactions(List<Person> cityRegister, List<Person> prisonRegister, Queue<string> newsFeed)
        {
            foreach (var person1 in cityRegister.ToList())
            {
                foreach (var person2 in cityRegister.ToList())
                {
                    bool checkPosition = person1.PositionX == person2.PositionX && person1.PositionY == person2.PositionY;

                    if (person1 is Police && person2 is Citizen && checkPosition)
                    {
                        newsNumber++;
                        Thread.Sleep(200);
                        newsFeed.Enqueue($" {newsNumber}. Polisen {person1.Name} säger hej till medborgaren {person2.Name}.".PadRight(70, ' '));
                    }
                    else if (person1 is Thief && person2 is Citizen && checkPosition)
                    {
                        string thing = person2.Inventory[Random.Shared.Next(person2.Inventory.Count)];
                        person1.Inventory.Add(thing);
                        person2.Inventory.Remove(thing);
                        newsNumber++;
                        robbedNumber++;
                        Thread.Sleep(200);
                        newsFeed.Enqueue($" {newsNumber}. Tjuven {person1.Name} tog {thing} från medborgaren {person2.Name}.".PadRight(70, ' '));
                    }
                    else if (person1 is Police && person2 is Thief && checkPosition && person2.Inventory.Count > 0)
                    {
                        List<string> stoleThings = person2.Inventory.ToList();

                        person1.Inventory = stoleThings;
                        newsNumber++;
                        arrestedNumber++;
                        Thread.Sleep(200);
                        newsFeed.Enqueue($" {newsNumber}. Polisen {person1.Name} arresterade tjuven {person2.Name}.".PadRight(70, ' '));

                        Board.ToPrison((Thief)person2, prisonRegister, cityRegister);
                    }
                    else if (person1 is Murderer && person2 != person1 && checkPosition)
                    {
                        newsNumber++;
                        murderedNumber++;
                        Thread.Sleep(200);
                        newsFeed.Enqueue($" {newsNumber}. {person2.Name} blev mördad!".PadRight(70, ' '));
                        cityRegister.Remove(person2);
                    }
                }
            }
        }
        public static void AddPopulation(List<Person> cityRegister, List<Person> prisonRegister, List<Person> poorRegister, Queue<string> newsFeed)
        {
            if (Console.KeyAvailable)
            {

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'c':
                        newsNumber++;
                        cityRegister.Add(new Citizen(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), Person.SetName()));
                        newsFeed.Enqueue($" {newsNumber}. En ny person flyttar in i staden.".PadRight(70, ' '));
                        break;
                    case 't':
                        newsNumber++;
                        cityRegister.Add(new Thief(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), Person.SetName()));
                        newsFeed.Enqueue($" {newsNumber}. En tjuv flyttar in i staden.".PadRight(70, ' '));
                        break;
                    case 'p':
                        newsNumber++;
                        cityRegister.Add(new Police(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), Person.SetName()));
                        newsFeed.Enqueue($" {newsNumber}. En polis flyttar in i staden.".PadRight(70, ' '));
                        break;
                    case 'm':
                        newsNumber++;
                        cityRegister.Add(new Murderer(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), Person.SetName()));
                        newsFeed.Enqueue($" {newsNumber}. En MÖRDARE är lös i staden.".PadRight(70, ' '));
                        break;
                    case 'n':
                        newsNumber++;
                        newsFeed.Enqueue($" {newsNumber}. NUKE INCOMING!".PadRight(70, ' '));
                        cityRegister.Clear();
                        prisonRegister.Clear();
                        poorRegister.Clear();
                        break;
                }
            }
        }
        public static void Nuke(Queue<string> newsFeed)
        {




        }
    }
}
