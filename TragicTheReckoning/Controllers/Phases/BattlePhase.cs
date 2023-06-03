using System;
using TragicTheReckoning.Controllers.Interfaces;
using TragicTheReckoning.Models;
using TragicTheReckoning.Views;

namespace TragicTheReckoning.Controllers.Phases
{
    public class BattlePhase: IPhase
    {
        private readonly BattleView _battleView;
        private Player _player1;
        private Player _player2;
        
        public BattlePhase(Player player1, Player player2)
        {
            _battleView = new BattleView();
            _player1 = player1;
            _player2 = player2;
        }
        
        public void RunPhase(int roundNumber, params Player[] players)
        {
            _battleView.RenderPhaseLabel(roundNumber, this.GetType());
            Console.WriteLine("Running Battle phase (not done yet)");
            _battleView.RenderBattleView(players);
            
            _battleView.RenderPhaseExit(this.GetType());
        }
    }
}