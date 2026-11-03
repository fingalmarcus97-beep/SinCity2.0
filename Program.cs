using Microsoft.Win32;
using System.Security.Cryptography.X509Certificates;

namespace SinCity2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> cityRegister = new List<Person>();
            List<Person> prisonRegister = new List<Person>();
            List<Person> poorRegister = new List<Person>();
            Queue<string> newsFeed = new Queue<string>();
            
            Board.Reg(cityRegister);

            while (true)
            {
                Board.CityBoard(100, 25, cityRegister);
                Board.MoveToPoorhouse(cityRegister, poorRegister);
                Console.WriteLine();
                Status.Population(cityRegister, prisonRegister);
                Board.PrisonBoard(10, 10, prisonRegister, cityRegister);
                Board.PoorBoard(50, 10, poorRegister);
                Interaction.Interactions(cityRegister, prisonRegister, newsFeed);
                Interaction.AddPopulation(cityRegister, newsFeed);
                Status.NewsFeed(newsFeed);
            }
        }
    }
}