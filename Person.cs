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

        public Person(int positionX, int positionY, string name)
        {
            PositionX = positionX;
            PositionY = positionY;
            Name = name;
            DirectionX = Random.Shared.Next(-1, 2);
            DirectionY = Random.Shared.Next(-1, 2);
            Inventory = new List<string>();
        }
    }

    internal class Citizen : Person
    {
        public Citizen(int positionX, int positionY, string name) : base(positionX, positionY, name)
        {
            Appearance = "C";
            Inventory.Add("Plånbok");
            Inventory.Add("Mobil");
            Inventory.Add("Nycklar");
            Inventory.Add("Hörlurar");
        }
    }

    internal class Thief : Person
    {
        public Thief(int positionX, int positionY, string name) : base(positionX, positionY, name)
        {
            Appearance = "T";
            
        }
    }

    internal class Police : Person
    {
        public Police(int positionX, int positionY, string name) : base(positionX, positionY, name)
        {
            Appearance = "P";
            
        }
    }
}
