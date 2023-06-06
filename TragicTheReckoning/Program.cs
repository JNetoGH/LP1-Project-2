using System;
using TragicTheReckoning.Controllers;
using TragicTheReckoning.Models;


namespace TragicTheReckoning
{
    class Program
    {
        private static string _player1Name;
        private static string _player2Name;
        
        static void Main()
        {
            Console.Write("Please provide the name for Player1: ");
            _player1Name = Console.ReadLine();
            Console.Write("Please provide the name for Player2: ");
            _player2Name = Console.ReadLine();
            
            GameLoop gameLoop = new GameLoop
            (
                new Player(_player1Name),
                new Player(_player2Name)    
            );
            
            gameLoop.Run();
            
        }
    }
}