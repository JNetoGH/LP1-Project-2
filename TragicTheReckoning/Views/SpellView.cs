using System;
using System.Text;

namespace TragicTheReckoning.Views
{
    public class SpellView: View
    {
        public void RenderPlayerHand(Player player)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n" + player.ToString());
            stringBuilder.Append($"\n\nhand:" );
            foreach (Card card in player.Hand)
                stringBuilder.Append($"\n{card}");
            Console.WriteLine(stringBuilder.ToString().TrimEnd(','));
        }
    }
}