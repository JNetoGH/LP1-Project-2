using System;
using TragicTheReckoning.Controllers.Interfaces;
using TragicTheReckoning.Models;
using TragicTheReckoning.Views;

namespace TragicTheReckoning.Controllers.Phases
{
    public class BuyingPhase: IPhase
    {
        private readonly BuyingView _buyingView;
   
        public BuyingPhase() => _buyingView = new BuyingView();

        public void RunPhase(Player player1, Player player2)
        {
            _buyingView.RenderPhaseLabel(this.GetType());
            Player[] players = new[] { player1, player2 };
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
                _buyingView.RenderHasBoughtANewCard(player, hasBoughtACard);
            }
            _buyingView.RenderPhaseExit(this.GetType());
        }

        private bool CanBuyACard(Player player) => player.Hand.Count < Player.MaxCardsInHand;
        
    }
}