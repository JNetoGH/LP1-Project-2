using System;
using TragicTheReckoning.Controllers.Interfaces;

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

        public void RunPhase(Player player1, Player player2)
        {
            Console.WriteLine("Running Battle phase (not implemented yet)");
            _battleView.RenderBattleView(player1, player2);
        }
    }
}