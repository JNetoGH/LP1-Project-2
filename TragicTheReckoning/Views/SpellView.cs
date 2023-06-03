using System;
using System.Text;
using TragicTheReckoning.Models;

namespace TragicTheReckoning.Views
{
    public class SpellView: View
    {
        
        public void RenderPlayerRoundIntroduction(Player player)
        {
            Console.Clear();
            string msg = $"Spell Phase of {player.Name} will occur.\nPlease make sure nobody is watching.\n";
            RenderExitWithInput(msg, ConsoleColor.Cyan);
        }
        
        public void RenderPlayerStats(Player player)
        {
            Console.WriteLine($"\nRound of: \n{player}");
        }

        public void RenderPlayerHand(Player player)
        {
            Console.WriteLine("\nHand:" );
            if (player.Hand.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This player arena hand is empty, you can't play a card this turn.\n");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < player.Hand.Count; i++)
            {
                Card card = player.Hand[i];
                stringBuilder.Append($"[{i+1}] {card}\n");
            }
            Console.WriteLine(stringBuilder.ToString().TrimEnd(','));
        }
        
        public void RenderPlayerCardsInArena(Player player)
        {
            Console.WriteLine("Cards in arena:" );
            if (player.CardsInArena.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This player arena sequence is empty, you can receive direct dmg.\n");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < player.CardsInArena.Count; i++)
            {
                Card card = player.CardsInArena.ToArray()[i];
                stringBuilder.Append($"[{i+1}] {card}\n");
            }
            Console.WriteLine(stringBuilder.ToString().TrimEnd(','));
        }

        public bool RenderTransferringOption()
        {
            return GetTreatedBooleanInput("Do you want to transfer a card from your hand to the arena?");
        }

        public string AskACardToPlayer()
        {
            return GetValidStringInput("Insert the number of the card you want to transfer to the arena: ");
        }

        public void RenderHasTransferringStatus(bool transferred)
        {
            if (transferred) Console.WriteLine("Card moved to arena");
            else RenderInvalidInputMsg("Sorry, you don't have enough mana do do it.");
        }
    }
}