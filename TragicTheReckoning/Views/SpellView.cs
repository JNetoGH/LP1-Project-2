using System;
using System.Text;

namespace TragicTheReckoning.Views
{
    public class SpellView: View
    {
        public void RenderPlayerHand(Player player)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(player.ToString());
            stringBuilder.Append($"\nhand:" );
            foreach (Card card in player.Hand)
                stringBuilder.Append($" {card.Name},");
            Console.WriteLine(stringBuilder.ToString().TrimEnd(','));
        }
    }
}