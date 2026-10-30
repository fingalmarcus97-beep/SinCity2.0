using System;
using System.Collections.Generic;
using System.Text;

namespace SinCity2._0
{
    internal class Interaction
    {
        static int newsNumber = 0;
        public static void Interactions(List<Person> cityRegister, List<Person> prisonRegister, Queue<string> newsFeed)
        {


            foreach (var person1 in cityRegister.ToList())
            {


                foreach (var person2 in cityRegister.ToList())
                {

                    if (person1 is Police && person2 is Citizen && person1.PositionX == person2.PositionX && person1.PositionY == person2.PositionY)
                    {
                        newsNumber++;
                        newsFeed.Enqueue($" {newsNumber}. Polisen {person1.Name} säger hej till medborgaren {person2.Name}.");


                    }
                    else if (person1 is Thief && person2 is Citizen && person1.PositionX == person2.PositionX && person1.PositionY == person2.PositionY)
                    {
                        string thing = person2.Inventory[0];
                        person1.Inventory.Add(thing);

                        person2.Inventory.Remove(thing);
                        newsNumber++;
                        newsFeed.Enqueue($" {newsNumber}. Tjuven {person1.Name} tog {thing} från medborgaren {person2.Name}.");


                    }
                    else if (person1 is Police && person2 is Thief && person1.PositionX == person2.PositionX && person1.PositionY == person2.PositionY && person2.Inventory.Count > 0)
                    {
                        List<string> stoleThings = person2.Inventory.ToList();

                        person1.Inventory = stoleThings;
                        newsNumber++;
                        newsFeed.Enqueue($" {newsNumber}. Polisen {person1.Name} arresterade tjuven {person2.Name}.");


                        Board.ToPrison((Thief)person2, prisonRegister, cityRegister);
                    }
                }

            }



        }


    }
}
