using System;

namespace TragicTheReckoning.Views
{
    public class BuyingView: View
    {
        
        public void RenderBuyingRound(Player player)
        {
            RenderExitWithInput($"\nATTENTION! {player.Name} will start");
        }
        
        public void RenderNotAllowedToBuyText(Player player)
        {
            Console.WriteLine($"\n{player.Name} has {Player.MaxCardsInHand} or more cards, you can't buy any more");
        }
        
        public bool RenderBuyingOption(Player player)
        {
            Console.WriteLine($"\n{player.Name} has less than {Player.MaxCardsInHand} cards, you can buy a new card!");
            return GetTreatedBooleanInput("Do you want to buy a new card?");
        }
        
        public void RenderHasBoughtANewCard(Player player, bool bought)
        {
            Console.WriteLine(bought
                ? $"{player.Name} bought a new card"
                : $"{player.Name} has chosen not to buy a new card");
        }
        
    }
}