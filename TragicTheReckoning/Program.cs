using TragicTheReckoning.Controllers;


namespace TragicTheReckoning
{
    class Program
    {
        static void Main(string[] args)
        {

            GameLoop gameLoop = new GameLoop
            (
                new Player("Jneto"),
                new Player("Bugs")
            );
            
            gameLoop.Run();
            
        }
    }
}