using TragicTheReckoning.Controllers;


namespace TragicTheReckoning
{
    class Program
    {
        static void Main(string[] args)
        {

            GameLoop gameLoop = new GameLoop
            (
                new Player("Jneto", 3, 10),
                new Player("Bugs",44, 123)
            );
            
            gameLoop.Run();
            
        }
    }
}