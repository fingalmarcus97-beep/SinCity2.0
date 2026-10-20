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

        public Person(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;

        }

    }
    class Test: Person 
    {
        public Test(int positionX, int positionY) :base (positionX,positionY)
        {
            positionX = 5;
            positionY = 10;

        }

    }
}
