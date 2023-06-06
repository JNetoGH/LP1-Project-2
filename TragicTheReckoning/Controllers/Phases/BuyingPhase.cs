using TragicTheReckoning.Controllers.Interfaces;
using TragicTheReckoning.Models;
using TragicTheReckoning.Views;

namespace TragicTheReckoning.Controllers.Phases
{
    public class BuyingPhase: IPhase
    {
        private readonly BuyingView _buyingView;
   
        public BuyingPhase() => _buyingView = new BuyingView();

        public void RunPhase(int roundNumber, params Player[] players)
        {
            _buyingView.RenderPhaseLabel(roundNumber,this.GetType());
            foreach (Player player in players)
            {
                if (!CanBuyACard(player))
                {
                    _buyingView.RenderNotAllowedToBuyText(player);
                    continue;
                }
                
                bool hasBoughtACard = _buyingView.RenderBuyingOption(player);
                if (hasBoughtACard)
                    player.BuyNewCard();
                _buyingView.RenderBuyingStatus(player, hasBoughtACard);
            }
            _buyingView.RenderPhaseExit(this.GetType());
        }

        private bool CanBuyACard(Player player) => player.Hand.Count < Player.MaxCardsInHand;
    }
}