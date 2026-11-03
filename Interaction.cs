using System;
using System.Collections.Generic;
using System.Text;

namespace SinCity2._0
{
    internal class Interaction
    {
        static int newsNumber = 0;
        public static int arrestedNumber = 0;
        public static int robbedNumber = 0;
        static string space = "                               ";
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
                        newsFeed.Enqueue($" {newsNumber}. Polisen {person1.Name} säger hej till medborgaren {person2.Name}.{space}");
                    }
                    else if (person1 is Thief && person2 is Citizen && checkPosition)
                    {
                        string thing = person2.Inventory[Random.Shared.Next(person2.Inventory.Count)];
                        person1.Inventory.Add(thing);
                        person2.Inventory.Remove(thing);
                        newsNumber++;
                        robbedNumber++;
                        Thread.Sleep(200);
                        newsFeed.Enqueue($" {newsNumber}. Tjuven {person1.Name} tog {thing} från medborgaren {person2.Name}.{space}");
                    }
                    else if (person1 is Police && person2 is Thief && checkPosition && person2.Inventory.Count > 0)
                    {
                        List<string> stoleThings = person2.Inventory.ToList();

                        person1.Inventory = stoleThings;
                        newsNumber++;
                        arrestedNumber++;
                        Thread.Sleep(200);
                        newsFeed.Enqueue($" {newsNumber}. Polisen {person1.Name} arresterade tjuven {person2.Name}.{space}");

                        Board.ToPrison((Thief)person2, prisonRegister, cityRegister);
                    }
                }
            }
        }
        public static void AddPopulation(List<Person> register, Queue<string> newsFeed)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'c':
                        newsNumber++;
                        register.Add(new Citizen(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), Person.SetName()));
                        newsFeed.Enqueue($" {newsNumber}. En ny person flyttar in i staden.{space}");
                        break;
                    case 't':
                        newsNumber++;
                        register.Add(new Thief(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), Person.SetName()));
                        newsFeed.Enqueue($" {newsNumber}. En tjuv flyttar in i staden.{space}");
                        break;
                    case 'p':
                        newsNumber++;
                        register.Add(new Police(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), Person.SetName()));
                        newsFeed.Enqueue($" {newsNumber}. En polis flyttar in i staden.{space}");
                        break;
                }
            }
        }
    }
}
