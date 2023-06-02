using System;
using System.Text;

namespace TragicTheReckoning.Views
{
    public class SpellView
    {
        public void RenderPlayerHand(Player player)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{player.Name} hand:" );
            foreach (Card card in player.Hand)
                stringBuilder.Append($" {card.Name},");
            Console.WriteLine(stringBuilder.ToString().TrimEnd(','));
        
            Console.WriteLine("\nPRESS ANY KEY TO CONTINUE");
            Console.ReadLine();
        }
    }
}