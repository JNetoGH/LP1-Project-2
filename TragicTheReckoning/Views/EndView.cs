using System;
using System.Collections.Generic;
using TragicTheReckoning.Models;

namespace TragicTheReckoning.Views
{
    public class EndView : View
    {
        public void DisplayWinner(Player winner)
        {
            if (winner != null)
            {
                Console.WriteLine(winner.Name + " wins!");
            }
            else
            {
                Console.WriteLine("The game is a draw!");
            }
            RenderExitWithInput();
        }
    }
}