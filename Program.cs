namespace SinCity2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> register = new List<Person>();
            Person.Reg(register);
            Person character = new Person(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), "C");
            Board.DrawBoard(100, 25, character, register);

        }
    }
}
