using System;

namespace TragicTheReckoning
{
    class Program
    {
        static void Main(string[] args)
        {

            Player player1 = new Player("Jneto", 3, 10);
            Player player2 = new Player("Bugs",44, 123);
            
            BattleView battleView = new BattleView(player1, player2);
            
            battleView.RenderPlayerHand(player1);
            battleView.RenderPlayerHand(player2);

        }
    }
}