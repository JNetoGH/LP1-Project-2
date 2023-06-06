using TragicTheReckoning.Models;
using TragicTheReckoning.Views;

namespace TragicTheReckoning.Controllers.Phases
{
    /// <summary>
    /// Handles the logic for the EndPhase and calls upon to EndView to inform the Players
    /// </summary>
    public class EndPhase
    {
        //Declaring the variables
        private readonly EndView _endView;

        /// <summary>
        /// Initializes the variables
        /// </summary>
        public EndPhase()
        {
            //Initializes the variables
            _endView = new EndView();
        }

        /// <summary>
        /// Calls the components of the End Phase in order
        /// </summary>
        /// <param name="winner">Which Player if any has won</param>
        public void RunPhase(Player winner)
        {
            //Writes that the game has ended
            _endView.GameHasEnded();
            //Writes which Player has won or if it ended in a Draw
            _endView.DisplayWinner(winner);
        }
    }
}