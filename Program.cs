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

            Board.Reg(cityRegister);

            while (true)
            {
                Board.CityBoard(100, 25, cityRegister);
                Board.Remove(cityRegister, poorRegister);
                Status.Population(cityRegister);
                Board.PrisonBoard(10, 10);
                Board.PoorBoard(50, 10, poorRegister);
                 
            }

            
            
        }
        
    }
}
                
