using System;
using TragicTheReckoning.Controllers;
using TragicTheReckoning.Models;


namespace TragicTheReckoning
{
    class Program
    {
        
        static void Main()
        {
            GameLoop gameLoop = new GameLoop();
            gameLoop.Run();
        }
    }
}