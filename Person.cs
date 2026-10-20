using System;
using System.Collections.Generic;
using System.Text;

namespace SinCity2._0
{
    internal class Person
    {
        public string Name { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int DirectionX { get; set; }
        public int DirectionY { get; set; }
        public List<string> Inventory { get; set; }
        public string Appearance { get; set; }

        public Person(int positionX, int positionY, string appearance)
        {
            PositionX = Random.Shared.Next(1, 99);
            PositionY = Random.Shared.Next(1, 24);
            Appearance = appearance;
        }

        

        public static void Reg(List<Person> register)
        {
            for (int i = 0; i < 20; i++)
            {
                register.Add(new Citizen(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), "C"));
            }

        }
        class Citizen : Person
        {
            public Citizen(int positionX, int positionY, string appearance) : base(positionX, positionY, appearance)
            {
                Appearance = "C";
            }
        }
        class Thief : Person
        {
            public Thief(int positionX, int positionY, string appearance) : base(positionX, positionY, appearance)
            {
                Appearance = "T";
            }
        }
        class Police : Person
        {
            public Police(int positionX, int positionY, string appearance) : base(positionX, positionY, appearance)
            {
                Appearance = "P";
            }
        }

    }
}
