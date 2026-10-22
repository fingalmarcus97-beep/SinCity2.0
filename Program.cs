namespace SinCity2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Person> register = new List<Person>();
            Board.Reg(register);
            
            Board.DrawBoard(100, 25, register);
            Board.PrisonBoard(10, 10);
        }
    }
}
