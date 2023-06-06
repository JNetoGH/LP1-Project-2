using System;
using TragicTheReckoning.Models;

namespace TragicTheReckoning.Views
{
    public class BattleView: View
    {
        public void RenderBattleView(Player[] players)
        {
            Console.WriteLine("Running Battle view (not implemented yet)");
        }

        public void RenderPlayerDeath(Player player)
        {
            Console.WriteLine(player.Name + " has died!");
        }

        public void RenderCardsInField(Player[] players)
        {
            foreach (Player player in players)
            {
                Console.WriteLine(player.Name + "'s Cards:");
                int cardNumber = 0;
                
                foreach (Card card in player.CardsInArena)
                {
                    cardNumber++;
                    Console.WriteLine("     " + cardNumber + ": " + card);
                }
                
                Console.WriteLine();
            }
        }

        public void NoDamageDealt(Player player1, Card card1, Player player2, Card card2)
        {
            Console.WriteLine(player1.Name + "'s " + card1.Name + " battles " + player2.Name 
                              + "'s " + card2.Name + "and neither manages to kill the other.");
        }
    }
}