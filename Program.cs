namespace SinCity2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Person> register = new List<Person>();
            //Person character = new Person(Random.Shared.Next(1, 99), Random.Shared.Next(1, 24), "?");
            Board.Reg(register);
            
            Board.DrawBoard(100, 25, register);

        }
    }
}
