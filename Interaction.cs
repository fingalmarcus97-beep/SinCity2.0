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
        public static void Interactions(List<Person> cityRegister, List<Person> prisonRegister, Queue<string> newsFeed)
        {

            foreach (var person1 in cityRegister.ToList())
            {
                foreach (var person2 in cityRegister.ToList())
                {

                    if (person1 is Police && person2 is Citizen && person1.PositionX == person2.PositionX && person1.PositionY == person2.PositionY)
                    {
                        newsNumber++;
                        Thread.Sleep(200);
                        newsFeed.Enqueue($" {newsNumber}. Polisen {person1.Name} säger hej till medborgaren {person2.Name}.                               ");
                    }
                    else if (person1 is Thief && person2 is Citizen && person1.PositionX == person2.PositionX && person1.PositionY == person2.PositionY)
                    {
                        string thing = person2.Inventory[Random.Shared.Next(person2.Inventory.Count)];
                        person1.Inventory.Add(thing);
                        person2.Inventory.Remove(thing);
                        newsNumber++;
                        robbedNumber++;
                        Thread.Sleep(200);
                        newsFeed.Enqueue($" {newsNumber}. Tjuven {person1.Name} tog {thing} från medborgaren {person2.Name}.                              ");
                    }
                    else if (person1 is Police && person2 is Thief && person1.PositionX == person2.PositionX && person1.PositionY == person2.PositionY && person2.Inventory.Count > 0)
                    {
                        List<string> stoleThings = person2.Inventory.ToList();

                        person1.Inventory = stoleThings;
                        newsNumber++;
                        arrestedNumber++;
                        Thread.Sleep(200);
                        newsFeed.Enqueue($" {newsNumber}. Polisen {person1.Name} arresterade tjuven {person2.Name}.                   ");

                        Board.ToPrison((Thief)person2, prisonRegister, cityRegister);
                    }
                }
            }
        }
        public static void AddPopulation(List<Person> register, Queue<string> newsFeed)
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
            string name = namnLista[rnd.Next(namnLista.Length)];
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case 'c':
                        newsNumber++;
                        register.Add(new Citizen(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), name));
                        newsFeed.Enqueue($" {newsNumber}. En ny person flyttar in i staden.                         ");
                        break;
                    case 't':
                        newsNumber++;
                        register.Add(new Thief(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), name));
                        newsFeed.Enqueue($" {newsNumber}. En tjuv flyttar in i staden.                              ");
                        break;
                    case 'p':
                        newsNumber++;
                        register.Add(new Police(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), name));
                        newsFeed.Enqueue($" {newsNumber}. En polis flyttar in i staden.                             ");
                        break;
                }
            }
        }
    }
}
