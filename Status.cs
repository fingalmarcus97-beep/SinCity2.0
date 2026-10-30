using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace SinCity2._0
{
    internal class Status
    {
        public static void Population(List<Person> register)
        {

            int totalPopulation = register.Count;
            Console.Write("Total population: " + totalPopulation);
            Console.Write(" || Total arrested: " + Interaction.arrestedNumber);
            Console.WriteLine(" || Total robbed: " + Interaction.robbedNumber);
            int totalCitizen = 0;
            int totalThief = 0;
            int totalPolice = 0;

            foreach (Person person in register)
            {
                if (person is Citizen)
                {
                    totalCitizen++;
                }
                else if (person is Thief)
                {
                    totalThief++;
                }
                else if (person is Police)
                {
                    totalPolice++;
                }

            }
            Console.Write("Citizens: " + totalCitizen);
            Console.Write(" || Thiefs: " + totalThief);
            Console.Write(" || Police: " + totalPolice + " ");

            Console.WriteLine();
        }
    }
}
