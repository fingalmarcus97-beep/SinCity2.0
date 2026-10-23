namespace SinCity2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Person> register = new List<Person>();
            Board.Reg(register);
            

            while (true)
            {
                Board.DrawBoard(100, 25, register);
                Board.PrisonBoard(10, 10);
                Thread.Sleep(100);
                Board.PoorBoard(50, 10);
                Status.Population(register);
            }
        }
    }
}
                
