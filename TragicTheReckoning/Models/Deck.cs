using System;
using System.Collections.Generic;
using TragicTheReckoning.Models;

namespace TragicTheReckoning
{
    public class Deck
    {

        public List<Card> cardPool { get; set; } = new List<Card>()
        {
            new Card("Flying Wand", 1, 1, 1),
            new Card("Flying Wand", 1, 1, 1),
            new Card("Flying Wand", 1, 1, 1),
            new Card("Flying Wand", 1, 1, 1),
            new Card("Severed Monkey Head", 1, 2, 1),
            new Card("Severed Monkey Head", 1, 2, 1),
            new Card("Severed Monkey Head", 1, 2, 1),
            new Card("Severed Monkey Head", 1, 2, 1),
            new Card("Mystical Rock Wall", 2, 0, 5),
            new Card("Mystical Rock Wall", 2, 0, 5),
            new Card("Lobster McCrabs", 2, 1, 3),
            new Card("Lobster McCrabs", 2, 1, 3),
            new Card("Goblin Troll", 3, 2, 2),
            new Card("Goblin Troll", 3, 2, 2),
            new Card("Scorching Heatwave", 4, 5, 3),
            new Card("Blind Minotaur", 3, 1, 3),
            new Card("Tim, The Wizard", 5, 6, 4),
            new Card("Sharply Dressed", 4, 3, 3),
            new Card("Blue Steel", 2, 2, 2),
            new Card("Blue Steel", 2, 2, 2)
        };
        
        public Deck() => this.Shuffle();

        private void Shuffle()
        {
            List<Card> shuffledDeck = new List<Card>();
            Random rnd = new Random();
            for(int i = cardPool.Count - 1; i>=0; i--)
            {
                int randomInt = rnd.Next(0,i);
                shuffledDeck.Add(cardPool[randomInt]);
                cardPool.RemoveAt(randomInt);
            }
            cardPool = shuffledDeck;
        }

    }
}