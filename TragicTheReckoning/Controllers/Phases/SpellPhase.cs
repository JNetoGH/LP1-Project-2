using System;
using TragicTheReckoning.Controllers.Interfaces;
using TragicTheReckoning.Views;

namespace TragicTheReckoning.Controllers.Phases
{
    public class SpellPhase: IPhase
    {
        private readonly SpellView _spellView;
        private Player _player1;
        private Player _player2;
        
        public SpellPhase(Player player1, Player player2)
        {
            _spellView = new SpellView();
            _player1 = player1;
            _player2 = player2;
        }
        
        public void RunPhase(Player player1, Player player2)
        {
            Console.WriteLine("\nRunning spell phase (not done yet)");
            _spellView.RenderPlayerHand(player1);
            _spellView.RenderPlayerHand(player2);
            
        }
    }
}