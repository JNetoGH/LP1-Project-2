using System;
using TragicTheReckoning.Controllers.Interfaces;
using TragicTheReckoning.Models;
using TragicTheReckoning.Views;

namespace TragicTheReckoning.Controllers.Phases
{
    public class SpellPhase: IPhase
    {
        private readonly SpellView _spellView;
        public SpellPhase() => _spellView = new SpellView();

        public void RunPhase(int roundNumber, params Player[] players)
        {
            foreach (Player player in players)
            {
                _spellView.RenderPlayerRoundIntroduction(player);
                RunTransferringLoop(roundNumber, player);
            }
            _spellView.ClearScreen();
            _spellView.RenderPhaseExit(this.GetType());
        }

        private void RunTransferringLoop(int roundNumber, Player player)
        {
            while (true) // transferring loop
            {
                _spellView.RenderPhaseLabel(roundNumber, this.GetType());
                _spellView.RenderPlayerStats(player);
                _spellView.RenderPlayerHand(player);
                _spellView.RenderPlayerCardsInArena(player);
                
                // Checks if the player wish to buy a card, if not just breaks the buying loop
                bool option = _spellView.RenderTransferringOption();
                if (!option) break;
                
                // Input Validation Sequence, this method already validates if it's neither null nor an empty string
                string input = _spellView.AskACardToPlayer();
                
                // Checks if the input is a number or not
                int index = 0;
                bool isInputANumber = int.TryParse(input, out index);
                if (isInputANumber)
                {
                    index -= 1; // transforms the input to the correspondent index
                    try // Checks if the input is in range with the hands and if player has enough mana to do so
                    {
                        // checks if the player has enough mana or not to transfer the card
                        bool hasEnoughMana = player.TrySendCartFromHandToArena(player.Hand[index]);
                        _spellView.RenderHasTransferringStatus(hasEnoughMana);
                    }
                    catch (Exception)
                    {
                        _spellView.RenderInvalidInputMsg();
                    }
                }
                else
                {
                    _spellView.RenderInvalidInputMsg();
                }
                _spellView.RenderExitWithInput();
            }
        }
        
    }
    
}