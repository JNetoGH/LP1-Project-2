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

        public void RunPhase(Player player1, Player player2)
        {
            while (true) // buying loop
            {
                _spellView.RenderPhaseLabel(this.GetType());
                _spellView.RenderPlayerStats(player1);
                _spellView.RenderPlayerHand(player1);
                _spellView.RenderPlayerCardsInArena(player1);
                
                // Checks if the player wish to buy a card, if not just breaks the buying loop
                bool option = _spellView.RenderTransferringOption();
                if (!option) break;
                
                // Input Validation Sequence, first of all, checks if it's neither null nor an empty string
                Console.Write("Insert the number of the card you want to transfer to the arena: ");
                string untreatedInput = Console.ReadLine();
                if (untreatedInput != null && ! untreatedInput.Equals(string.Empty))
                {
                    untreatedInput = untreatedInput.ToUpper().Trim();
                    
                    // Checks if the input is a number or not
                    int index = 0;
                    bool isInputANumber = int.TryParse(untreatedInput, out index);
                    if (isInputANumber)
                    {
                        index -= 1; // transforms the input to the correspondent index
                        try // Checks if the input is in range with the hands and if player has enough mana to do so
                        {
                            // checks if the player has enough mana or not to transfer the card
                            bool hasEnoughMana = player1.TrySendCartFromHandToArena(player1.Hand[index]);
                            if (hasEnoughMana) Console.WriteLine("Card moved to arena");
                            else _spellView.RenderInvalidInputMsg("Sorry, you don't have enough mana do do it.");
                        }
                        catch (Exception)
                        {
                            _spellView.RenderInvalidInputMsg("Sorry the Chosen Card doesn't exist.");
                        }
                    }
                }
                else _spellView.RenderInvalidInputMsg();
                
                
                Console.WriteLine("\nPress enter to continue");
                Console.ReadLine();
            }
            
            _spellView.RenderPhaseExit(this.GetType());
        }
        
        
    }
    

    
}