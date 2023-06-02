﻿using System;
using System.Collections.Generic;

namespace TragicTheReckoning
{
    public class Deck
    {

        public List<Card> cardPool { get; set; } = new List<Card>()
        {
            new Card("Bugs", 2,3,4),
            new Card("ijdeijdei", 2, 5, 7),
            new Card("iejiejd", 4, 5, 8),
            new Card("dkoekoe", 2, 3, 4),
            new Card("cnnbnmbs", 3, 1, 6),
            new Card("qwqryr", 7, 3, 1),
        };

        public Deck()
        {
            cardPool = Shuffle(cardPool);
        }
        
        private List<Card> Shuffle(List<Card> target)
        {
            List<Card> shuffledDeck = new List<Card>();
            Random rnd = new Random();
            for(int i = target.Count - 1; i>=0; i--)
            {
                int randomInt = rnd.Next(0,i);
                shuffledDeck.Add(target[randomInt]);
                target.RemoveAt(randomInt);
            }
            return shuffledDeck;
        }
        
    }
}