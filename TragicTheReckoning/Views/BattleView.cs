using System;
using System.Text;

namespace TragicTheReckoning
{
    public class BattleView
    {
        private Player _player1;
        private Player _player2;

        public BattleView(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public void RenderPlayerHand(Player player)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{player.Name} hand:" );
            foreach (Card card in player.Deck.Hand)
                stringBuilder.Append($" {card.Name},");
            Console.WriteLine(stringBuilder.ToString().TrimEnd(','));
        }
        
    }
}