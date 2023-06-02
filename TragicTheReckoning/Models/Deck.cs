using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TragicTheReckoning
{
    public class Deck
    {
        private List<Card> cardPool = new List<Card>()
        {
            new Card("Bugs", 2,3,4),
            new Card("ijdeijdei", 2, 5, 7),
            new Card("iejiejd", 4, 5, 8),
            new Card("dkoekoe", 2, 3, 4),
            new Card("cnnbnmbs", 3, 1, 6),
            new Card("qwqryr", 7, 3, 1),
        };

        public List<Card> shuffledDeck { get; private set; } = new List<Card>();

        public List<Card> Hand { get; private set; }

        public void Shuffle()
        {
            Random rnd = new Random();

            for(int i = cardPool.Count - 1; i>=0; i--)
            {
                int randomInt = rnd.Next(0,i);
                shuffledDeck.Add(cardPool[randomInt]);
                cardPool.RemoveAt(randomInt);
            }
        }
    }
}