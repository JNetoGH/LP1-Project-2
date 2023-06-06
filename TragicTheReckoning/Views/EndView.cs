using System;
using TragicTheReckoning.Models;

namespace TragicTheReckoning.Views
{
    /// <summary>
    /// Has the methods which inform the Players of what is occurring in the End Phase
    /// </summary>
    public class EndView : View
    {
        /// <summary>
        /// Writes that the game has ended
        /// </summary>
        public void GameHasEnded()
        {
            //Writes that the game has ended
            Console.WriteLine("This game has come to an end!");
        }
        
        /// <summary>
        /// Writes which Player has won the game or if it ended in a Draw
        /// </summary>
        /// <param name="winner">The Player who won or a null reference if it was a Draw</param>
        public void DisplayWinner(Player winner)
        {
            //If there is a Winner
            if (winner != null)
            {
                //Write who won
                Console.WriteLine(winner.Name + " wins!");
            }
            //If there's no Winner
            else
            {
                //Write that it was a Draw
                Console.WriteLine("The game is a draw!");
            }
            //Wait for an Input before proceeding
            RenderExitWithInput();
        }
    }
}