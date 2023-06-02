using System;

namespace TragicTheReckoning
{
    class Program
    {
        static void Main(string[] args)
        {

            Player player1 = new Player("Jneto", 3, 10);
            Player player2 = new Player("Bugs",44, 123);
            
            BattleView battleView = new BattleView(player1, player2);
            
            //battleView.RenderPlayerHand(player1);
            //battleView.RenderPlayerHand(player2);

            Deck deck1 = new Deck();
            Deck deck2 = new Deck();
            Deck deck3 = new Deck();

            deck1.Shuffle();
            deck2.Shuffle();
            deck3.Shuffle();
            
            foreach(Card i in deck1.shuffledDeck)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            foreach (Card i in deck2.shuffledDeck)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            foreach (Card i in deck3.shuffledDeck)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
    }
}