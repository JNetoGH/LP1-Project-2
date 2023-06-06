using System;
using TragicTheReckoning.Models;

namespace TragicTheReckoning.Views
{
    /// <summary>
    /// Has the methods which inform the Players of what is occurring in the Battle Phase
    /// </summary>
    public class BattleView: View
    {
        /// <summary>
        /// Writes which Player has died
        /// </summary>
        /// <param name="player">Reference a Player</param>
        public void RenderPlayerDeath(Player player)
        {
            //Writes which Player has died
            Console.WriteLine(player.Name + " has died!");
        }

        /// <summary>
        /// Writes all the cards in play from both players 
        /// </summary>
        /// <param name="players">Receives an array containing references of both Players</param>
        public void RenderCardsInField(Player[] players)
        {
            //Iterate through each player
            foreach (Player player in players)
            {
                //Write which Player this cards belong to
                Console.WriteLine(player.Name + "'s Cards:");
                int cardNumber = 0;
                
                //Iterate through each card
                foreach (Card card in player.CardsInArena)
                {
                    //Write the name of each Card
                    cardNumber++;
                    Console.WriteLine("     " + cardNumber + ": " + card);
                }
                //Write an empty line for spacing purposes 
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Write that neither card is able to deal damage to each other
        /// </summary>
        /// <param name="player1">A Player</param>
        /// <param name="card1">The first Player's card</param>
        /// <param name="player2">The other Player</param>
        /// <param name="card2">The other Player's card</param>
        public void NoDamageDealt(Player player1, Card card1, Player player2, Card card2)
        {
            //Write that neither card is able to deal damage to each other
            Console.WriteLine(player1.Name + "'s " + card1.Name + " battles " + player2.Name 
                              + "'s " + card2.Name + " and neither manages to kill the other.");
        }

        /// <summary>
        /// Write what card dealt damage to which one and how much it dealt
        /// </summary>
        /// <param name="player1">A Player</param>
        /// <param name="card1">The first Player's card</param>
        /// <param name="player2">The other Player</param>
        /// <param name="card2">The other Player's card</param>
        public void RenderDamageDealt(Player player1, Card card1, Player player2, Card card2)
        {
            //Store the damage that the card dealt to the other so it can be written
            int damage = card1.currentAttackPoints >= card2.DefencePoints ? card2.DefencePoints 
                : card1.currentAttackPoints;
            
            //Write what card dealt damage to which one and how much it dealt
            Console.WriteLine(player1.Name + "'s " + card1.Name + " deals " +
                              damage + " damage to " + player2.Name + "'s " + card2.Name);
        }

        /// <summary>
        /// Writes which Player only has cards remaining
        /// </summary>
        /// <param name="player">A Player</param>
        public void OnlyOnePlayerHasCards(Player player)
        {
            //Writes which Player only has cards remaining
            Console.WriteLine("As only " + player.Name + " has monsters remaining, they launch an all-out attack!");
            //Wait for an Input from the Player before proceeding
            RenderExitWithInput();
            //Clears the Screen
            ClearScreen();
        }

        /// <summary>
        /// Writes which card dealt damage directly to which Player and how much it did
        /// </summary>
        /// <param name="player">A Player</param>
        /// <param name="card">The Player's Card</param>
        /// <param name="otherPlayer">The other Player</param>
        public void DirectDamageDealt(Player player, Card card, Player otherPlayer)
        {
            //Writes which card dealt damage directly to which Player and how much it did
            Console.WriteLine(player.Name + "'s " + card.Name + " attacks " + otherPlayer.Name +
                              " directly, dealing " + card.currentAttackPoints + " damage!");
        }

        /// <summary>
        /// Writes that a Player's cards have been removed from the battlefield
        /// </summary>
        /// <param name="player">A Player</param>
        public void ExhaustedCards(Player player)
        {
            //Writes that a Player's cards have been removed from the battlefield
            Console.WriteLine("Following the all-out attack, " + player.Name +
                              "'s monsters are exhausted and retire from the battlefield.");
        }

        /// <summary>
        /// Asks the player if they wish to surrender and returns their response as a bool
        /// </summary>
        /// <param name="player">A Player</param>
        /// <returns>Boolean depending on their response</returns>
        public bool SurrenderRequest(Player player)
        {
            //Asks the player if they wish to surrender and returns their response as a bool
            return GetTreatedBooleanInput("Do you wish to forfeit, " + player.Name + "?");
        }
    }
}