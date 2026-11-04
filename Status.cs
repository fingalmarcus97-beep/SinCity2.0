using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Xml.Xsl;

namespace SinCity2._0
{
    internal class Status
    {
        public static void Population(List<Person> cityRegister, List<Person> prisonRegister)
        {
            int prisonPopulation = prisonRegister.Count;
            int totalPopulation = cityRegister.Count;

            Console.Write($"Total population: {totalPopulation}");
            Console.Write($" || Total arrested: {Interaction.arrestedNumber}");
            Console.Write($" || Total robbed: {Interaction.robbedNumber} ||".PadRight(23, ' '));

            int totalCitizen = 0;
            int totalThief = 0;
            int totalPolice = 0;
            int totalMurderer = 0;

            foreach (Person person in cityRegister)
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($" Total murdered: {Interaction.murderedNumber}".PadRight(70, ' '));
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine();
            }

            Console.Write($"Citizens: {totalCitizen}");
            Console.Write($" || Thiefs: {totalThief}");
            Console.Write($" || Police: {totalPolice}");
            Console.Write($" || Prisoners: {prisonPopulation} ||".PadRight(21, ' '));
            if (totalMurderer > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($" Murderers: {totalMurderer} ".PadRight(70, ' '));
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }

        public static void NewsFeed(Queue<string> newsFeed)
        {
            while (newsFeed.Count() > 10)
            {
                newsFeed.Dequeue();
            }

            Console.WriteLine();
            Console.WriteLine("█ NEWSFEED ██████████████████████████████████████████████████");
            foreach (string message in newsFeed.ToList())
            {
                if (message.Contains("MÖRDARE") || message.Contains("mördad"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (message.Contains("NUKE") || message.Contains("IMPACT") || message.Contains("UTPLÅNAT"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(message);
                    Thread.Sleep(1000);
                    newsFeed.Clear();
                    for (int i = 0; i < 10; i++)
                    {
                        newsFeed.Enqueue(" ".PadRight(70, ' '));
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else { Console.WriteLine(message); }
            }
            Console.WriteLine("█████████████████████████████████████████████████████████████");
        }
    }
}
