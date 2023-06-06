using System;
using TragicTheReckoning.Controllers.Interfaces;
using TragicTheReckoning.Models;
using TragicTheReckoning.Views;

namespace TragicTheReckoning.Controllers.Phases
{
    public class EndPhase
    {
        private readonly EndView _endView;

        public EndPhase()
        {
            _endView = new EndView();
        }

        public void RunPhase(Player winner)
        {
            _endView.GameHasEnded();
            _endView.DisplayWinner(winner);
        }
    }
}