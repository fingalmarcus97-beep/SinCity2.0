using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace SinCity2._0
{
    internal class Status
    {
        public static void Population(List<Person> register, List<Person> prisonRegister)
        {
            int prisonPopulation = prisonRegister.Count;
            int totalPopulation = register.Count;
            Console.Write($"Total population: {totalPopulation}");
            Console.Write($" || Total arrested: {Interaction.arrestedNumber}");
            Console.Write($" || Total robbed: {Interaction.robbedNumber}");
            
            

            int totalCitizen = 0;
            int totalThief = 0;
            int totalPolice = 0;
            int totalMurderer = 0;

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
                else if (person is Murderer)
                {
                    totalMurderer++;
                }
            }

            if (totalMurderer > 0)
            {
                
                Console.WriteLine($" || Total murdered: {Interaction.murderedNumber}".PadRight(70, ' '));

            }
            else
            {
                Console.WriteLine();
            }

            Console.Write($"Citizens: {totalCitizen}");
            Console.Write($" || Thiefs: {totalThief}");
            Console.Write($" || Police: {totalPolice}");
            Console.Write($" || Prisoners: {prisonPopulation}");
            if (totalMurderer > 0)
            {
                Console.Write($" || Murderers: {totalMurderer} ".PadRight(70, ' '));
      
            }
            Console.WriteLine();
        }

        public static void NewsFeed (Queue<string> newsFeed)
        {
            while (newsFeed.Count() > 10)
            {
                newsFeed.Dequeue();
            }

            Console.WriteLine();
            Console.WriteLine("█ NEWSFEED ██████████████████████████████████████████████████");
            foreach (string message in newsFeed.ToList())
            {
                Console.WriteLine(message);
            }
            Console.WriteLine("█████████████████████████████████████████████████████████████");
        }
    }
}
