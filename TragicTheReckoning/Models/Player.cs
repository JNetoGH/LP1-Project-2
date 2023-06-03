using System;
using System.Collections.Generic;

namespace TragicTheReckoning
{
    public class Player
    {
        public string Name { get; private set; }
        public int HealthPoints { get; private set; }
        public int ManaPoints { get; set; }
        
        private Deck Deck { get; set; }
        public List<Card> Hand { get; private set; }
        
        public Player(string name, int manaPoints, int healthPoints)
        {
            Name = name;
            ManaPoints = manaPoints;
            HealthPoints = healthPoints;
            
            Deck = new Deck();
            Hand = new List<Card>();
            
            // GIVE THE PLAYER THE 6 INITIAL CARDS, THE DECK IS ALREADY SHUFFLED
            for (int i = 0; i < 5; i++)
                Buy();
            
        }
        
        public void Buy()
        {
            Card c = Deck.cardPool[Deck.cardPool.Count - 1];
            Hand.Add(c);
            Deck.cardPool.Remove(c);
        }
    }
}