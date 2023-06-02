using System;
using System.Text;

namespace TragicTheReckoning.Views
{
    public class SpellView
    {
        public void RenderSpellView(Player player1, Player player2)
        {
            Console.WriteLine("Running Spell View render\n");
            RenderPlayerHand(player1);
            RenderPlayerHand(player2);
        }
        
        private void RenderPlayerHand(Player player)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{player.Name} hand:" );
            foreach (Card card in player.Deck.Hand)
                stringBuilder.Append($" {card.Name},");
            Console.WriteLine(stringBuilder.ToString().TrimEnd(','));
        
            Console.WriteLine("\nPRESS ANY KEY TO CONTINUE");
            Console.ReadLine();
        }
    }
}