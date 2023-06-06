using System;
using TragicTheReckoning.Models;

namespace TragicTheReckoning.Views
{
    public class BattleView: View
    {
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
                              + "'s " + card2.Name + " and neither manages to kill the other.");
        }

        public void RenderDamageDealt(Player player1, Card card1, Player player2, Card card2)
        {
            int damage = card1.currentAttackPoints >= card2.DefencePoints ? card2.DefencePoints 
                : card1.currentAttackPoints;
            
            Console.WriteLine(player1.Name + "'s " + card1.Name + " deals " +
                              damage + " damage to " + player2.Name + "'s " + card2.Name);
        }

        public void OnlyOnePlayerHasCards(Player player)
        {
            Console.WriteLine("As only " + player.Name + " has monsters remaining, they launch an all-out attack!");
            RenderExitWithInput();
            ClearScreen();
        }

        public void DirectDamageDealt(Player player, Card card, Player otherPlayer)
        {
            Console.WriteLine(player.Name + "'s " + card.Name + " attacks " + otherPlayer.Name +
                              " directly, dealing " + card.currentAttackPoints + " damage!");
        }

        public void ExhaustedCards(Player player)
        {
            Console.WriteLine("Following the all-out attack, " + player.Name +
                              "'s monsters are exhausted and retire from the battlefield.");
        }
    }
}