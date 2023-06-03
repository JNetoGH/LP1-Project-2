using TragicTheReckoning.Controllers.Interfaces;
using TragicTheReckoning.Views;

namespace TragicTheReckoning.Controllers.Phases
{
    public class SpellPhase: IPhase
    {
        private readonly SpellView _spellView;
        
        public SpellPhase()
        {
            _spellView = new SpellView();
        }
        
        public void RunPhase(Player player1, Player player2)
        {
            _spellView.RenderPhaseLabel(this.GetType());
            
            
            _spellView.RenderPlayerHand(player1);
            _spellView.RenderPlayerHand(player2);
            _spellView.RenderPhaseExit(this.GetType());
        }
    }
}