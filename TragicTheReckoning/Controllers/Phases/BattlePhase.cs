using System;
using TragicTheReckoning.Controllers.Interfaces;
using TragicTheReckoning.Models;
using TragicTheReckoning.Views;

namespace TragicTheReckoning.Controllers.Phases
{
    /// <summary>
    /// Handles the Battle Phase and calls the BattleView to present the information to the player
    /// </summary>
    public class BattlePhase : IPhase
    {
        //Declaring the variables
        private readonly BattleView _battleView;
        private Player _player1;
        private Player _player2;

        /// <summary>
        /// Initializes the variables
        /// </summary>
        /// <param name="player1">Reference to Player 1</param>
        /// <param name="player2">Reference to Player 2</param>
        public BattlePhase(Player player1, Player player2)
        {
            //Initializes the variables
            _battleView = new BattleView();
            _player1 = player1;
            _player2 = player2;
        }

        /// <summary>
        /// Calls the components of the Battle Phase in order
        /// </summary>
        /// <param name="roundNumber">The number of the current round</param>
        /// <param name="players">Receives an array containing the players</param>
        public void RunPhase(int roundNumber, params Player[] players)
        {
            _battleView.RenderPhaseLabel(roundNumber, this.GetType());
            BattlePhaseLoop(players);
            ForfeitOption(players);
            _battleView.RenderPhaseExit(this.GetType());
        }

        /// <summary>
        /// Handles the logic portion of the Battle Phase and calls the render for that logic
        /// </summary>
        /// <param name="players">Receives an array containing the players</param>
        private void BattlePhaseLoop(Player[] players)
        {
            //Resets a card's AttackPoints to the maxAttackPoints in case the cards have survived from a previous round
            ResetAttackValues(players);
            
            //Showcases the cards in the field to the players
            _battleView.RenderCardsInField(players);

            //While both players have cards in the arena
            while (_player1.CardsInArena.Count > 0 && _player2.CardsInArena.Count > 0)
            {
                //Initialize variables containing the first cards in play
                Card player1Card = _player1.CardsInArena[0];
                Card player2Card = _player2.CardsInArena[0];

                //If both players' first cards have no remaining Attack Points
                if (player1Card.currentAttackPoints <= 0 && player2Card.currentAttackPoints <= 0)
                {
                    //Write that the cards cannot kill each other
                    _battleView.NoDamageDealt(_player1, player1Card, _player2, player2Card);
                    //Break out from the Battle Phase loop
                    break;
                }

                //If both players' first cards still have Defence Points
                if (player1Card.DefencePoints > 0 && player2Card.DefencePoints > 0)
                {
                    //Handle the combat between both cards
                    CardCombat(player1Card, player2Card);
                }

                //If a card still has remaining Attack Points and Defence Points, it deals
                //damage to the following cards until it exhausts its Attack Points 
                ExtraDamage(_player1, player1Card, _player2);
                ExtraDamage(_player2, player2Card, _player1);
                
                //Iterate through each player
                foreach (Player player in players)
                {
                    //Remove all cards, that no longer have Defence Points, from play
                    RemoveDeadCards(players);
                }
            }

            //If only one player has cards in play, they deal damage to the other player directly and are then removed
            OneSidedResolver(_player1, _player2);

            //Checks if either player has died and if yes, it ends the GameLoop
            CheckDeadPlayer(_player1, _player2);
        }

        /// <summary>
        /// Iterates through the cards in play of each player and resets their AttackPoints to the maxAttackPoints
        /// in case the cards have survived from a previous round
        /// </summary>
        /// <param name="players">Receives an array containing the players</param>
        private void ResetAttackValues(Player[] players)
        {
            //Iterate through each player
            foreach (Player player in players)
            {
                //Iterate through each card in play
                foreach (Card card in player.CardsInArena)
                {
                    //Reset their current AttackPoints to their default value
                    card.currentAttackPoints = card.maxAttackPoints;
                }
            }
        }

        /// <summary>
        /// Handles the combat logic between two cards
        /// </summary>
        /// <param name="card1">Reference to a card</param>
        /// <param name="card2">Reference to the opposing card</param>
        private void CardCombat(Card card1, Card card2)
        {
            //Store the Attack Points of the card
            int attackPoints = card1.currentAttackPoints;
            //Inform the players of what's happening and the values of it
            _battleView.RenderDamageDealt(_player1, card1, _player2, card2);
            //Remove the opposing card's Defence Points to the current card's Attack Points
            card1.currentAttackPoints -= card2.DefencePoints;
            //Remove the stored Attack Points from the opposing card's Attack Points
            card2.DefencePoints -= attackPoints;

            //Repeats the operation above on the other way around
            attackPoints = card2.currentAttackPoints;
            _battleView.RenderDamageDealt(_player2, card2, _player1, card1);
            card2.currentAttackPoints -= card1.DefencePoints;
            card1.DefencePoints -= attackPoints;
        }

        /// <summary>
        /// If a card still has remaining Attack Points and Defence Points, it continually deals damage to
        /// the following cards until it exhausts its Attack Points
        /// </summary>
        /// <param name="player">Reference to the Player who controls the card</param>
        /// <param name="card">Reference to the Card in play</param>
        /// <param name="otherPlayer">Reference to the opposing Player</param>
        private void ExtraDamage(Player player, Card card, Player otherPlayer)
        {
            //Initialize an index variable at 1
            int index = 1;
            
            //While the card still has remaining AttackPoints and Defence Points
            while(card.currentAttackPoints > 0 && card.DefencePoints > 0)
            {
                //Store the card's currentAttackPoints
                int currentAttackPoints = card.currentAttackPoints;

                //Try to perform the following operations
                try
                {
                    //Inform the players of the logic and the values of what happens in this step
                    _battleView.RenderDamageDealt(player, card, otherPlayer,
                        otherPlayer.CardsInArena[index]);
                    
                    //Remove the Defense Points of the other card from the Attack Points of the card
                    card.currentAttackPoints -= otherPlayer.CardsInArena[index].DefencePoints;
                    //Remove the stored attack points from the other card's Defense Points
                    otherPlayer.CardsInArena[index].DefencePoints -= currentAttackPoints;
                }
                //If the index ever falls out of range
                catch
                {
                    //Exit out of this loop
                    break;
                }
                
                //Increment the index variables
                index++;
            }
        }

        /// <summary>
        /// Removes all cards with 0 or less Defense Points from the game
        /// </summary>
        /// <param name="players">Receives an array containing the players</param>
        private void RemoveDeadCards(Player[] players)
        {
            //Iterate through both players
            foreach (Player player in players)
            {
                //Remove all cards that have 0 or less Defense Points from the game
                player.CardsInArena.RemoveAll(card => card.DefencePoints <= 0);
            }
        }

        /// <summary>
        /// If only one players has cards remaining, they deal their damage directly to the opposing
        /// player and then get removed from the game
        /// </summary>
        /// <param name="player1">Reference to Player 1</param>
        /// <param name="player2">Reference to Player 2</param>
        private void OneSidedResolver(Player player1, Player player2)
        {
            //If there's not only one Player with cards in play, exit out of this method
            if (!(player1.CardsInArena.Count > 0 ^ player2.CardsInArena.Count > 0)) return;
            
            //If Player 1 has cards in play
            if (player1.CardsInArena.Count > 0)
            {
                //Inform the players that only Player 1 has cards in play
                _battleView.OnlyOnePlayerHasCards(player1);
                
                //For every card in play
                foreach (Card card in player1.CardsInArena)
                {
                    //Inform the player's that the card will deal X damage directly to the other player
                    _battleView.DirectDamageDealt(player1, card, player2);
                    //Have that card deal damage directly to the other player's Health Points
                    _player2.HealthPoints -= card.currentAttackPoints;
                }
                //Inform the players that every card will be removed from play
                _battleView.ExhaustedCards(player1);
                //Remove all cards from play
                _player1.CardsInArena.Clear();
            }
            //If Player 2 has cards in play
            else
            {
                //Inform the players that only Player 1 has cards in play
                _battleView.OnlyOnePlayerHasCards(player2);
                
                //For every card in play
                foreach (Card card in _player2.CardsInArena)
                {
                    //Inform the player's that the card will deal X damage directly to the other player
                    _battleView.DirectDamageDealt(player2, card, player1);
                    //Have that card deal damage directly to the other player's Health Points
                    _player1.HealthPoints -= card.currentAttackPoints;
                }
                //Inform the players that every card will be removed from play
                _battleView.ExhaustedCards(player2);
                //Remove all cards from play
                _player2.CardsInArena.Clear();
            }
        }

        /// <summary>
        /// Checks if either players has died and terminates the GameLoop
        /// </summary>
        /// <param name="player1">Reference to Player 1</param>
        /// <param name="player2">Reference to Player 1</param>
        /// <exception cref="Exception"></exception>
        private void CheckDeadPlayer(Player player1, Player player2)
        {
            //If Player 1's Health Points are 0 or lower
            if (_player1.HealthPoints <= 0)
            {
                //Inform the players of who died
                _battleView.RenderPlayerDeath(_player1);
                //Throw the exception which will terminate the GameLoop
                throw new Exception();
            }
            //If Player 2's Health Points are 0 or lower
            else if (_player2.HealthPoints <= 0)
            {
                //Inform the players of who died
                _battleView.RenderPlayerDeath(_player2);
                //Throw the exception which will terminate the GameLoop
                throw new Exception();
            }
        }

        /// <summary>
        /// Asks both players if they wish to forfeit. If they do, ends the game and awards the win to the opponent
        /// </summary>
        /// <param name="players">Array which contains both players</param>
        private void ForfeitOption(Player[] players)
        {
            //Waits for Player's input before proceeding
            _battleView.RenderExitWithInput();
            //Clears the screen
            _battleView.ClearScreen();
            
            //Iterates through each players
            foreach (Player player in players)
            {
                //Asks if they wish to surrender and if they do...
                if (_battleView.SurrenderRequest(player))
                {
                    //...sets their Health Points to 0
                    player.HealthPoints = 0;
                    //Breaks the GameLoop
                    throw new Exception();
                };
            }
        }
    }
}