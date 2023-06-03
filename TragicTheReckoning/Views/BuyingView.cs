using System;
using TragicTheReckoning.Controllers;

namespace TragicTheReckoning.Views
{
    public class BuyingView: View
    {

        public void RenderNotAllowedToBuyText(Player player)
        {
            Console.WriteLine($"{player.Name} has {GameLoop.MaxCardsInHand} or less, you can't buy any more cards");
        }

        public bool RenderBuyingTexts(Player player)
        {
            Console.WriteLine($"{player.Name} has less than {GameLoop.MaxCardsInHand}, you can buy a new card!");
            return GetTreatedBooleanInput("Do you want to buy a new card?");
        }
        
    }
}