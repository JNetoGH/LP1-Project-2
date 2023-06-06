using System;
using TragicTheReckoning.Models;

namespace TragicTheReckoning.Views
{
    public class BuyingView: View
    {

        private void RenderPlayerBuyingPhaseHeader(Player player)
        {
            Console.WriteLine($"\n{player.Name}: " +
                              $"(hand: {player.Hand.Count} cards) (deck: {player.Deck.cardPool.Count} cards)");
        }
        
        public void RenderNotAllowedToBuyText(Player player)
        {
            RenderPlayerBuyingPhaseHeader(player);
            Console.WriteLine($"{player.Name} has {Player.MaxCardsInHand} or more cards, you can't buy any cards more");
        }

        public bool RenderBuyingOption(Player player)
        {
            RenderPlayerBuyingPhaseHeader(player);
            Console.WriteLine($"{player.Name} has less than {Player.MaxCardsInHand} cards, you can buy a new card!");
            return GetTreatedBooleanInput("Do you want to buy a new card?");
        }
        
        public void RenderBuyingStatus(Player player, bool bought)
        {
            Console.WriteLine(bought
                ? $"{player.Name} bought a new card"
                : $"{player.Name} has chosen not to buy a new card");
        }
        
    }
}