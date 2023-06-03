using System;
using TragicTheReckoning.Controllers.Interfaces;
using TragicTheReckoning.Views;

namespace TragicTheReckoning.Controllers.Phases
{
    public class BuyingPhase: IPhase
    {
        private readonly BuyingView _buyingView;
   
        public BuyingPhase() => _buyingView = new BuyingView();

        public void RunPhase(Player player1, Player player2)
        {
            Console.WriteLine("Running buying phase");
            
            if (!CanBuyACard(player1))
                _buyingView.RenderNotAllowedToBuyText(player1);
            else if (_buyingView.RenderBuyingTexts(player1))
                    player1.Buy();
            
            if (!CanBuyACard(player2))
                _buyingView.RenderNotAllowedToBuyText(player2);
            else if (_buyingView.RenderBuyingTexts(player2))
                    player2.Buy();
        }

        private bool CanBuyACard(Player player) => player.Hand.Count < GameLoop.MaxCardsInHand;
        
    }
}