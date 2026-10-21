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
        }
    }

    internal class Citizen : Person
    {
        public Citizen(int positionX, int positionY, string name) : base(positionX, positionY, name )
        {
            Appearance = "C";
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
